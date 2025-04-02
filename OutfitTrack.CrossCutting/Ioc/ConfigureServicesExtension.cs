using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using OutfitTrack.Application.ApiManagement;
using OutfitTrack.Application.Interfaces;
using OutfitTrack.Application.Mapping;
using OutfitTrack.Application.Security;
using OutfitTrack.Application.Services;
using OutfitTrack.CrossCutting.Swagger;
using OutfitTrack.Domain.Interfaces;
using OutfitTrack.Infraestructure;
using OutfitTrack.Infraestructure.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.RateLimiting;

namespace OutfitTrack.CrossCutting.Ioc;

public static class ConfigureServicesExtension
{
    private static IServiceCollection ServiceCollection { get; set; } = new ServiceCollection();
    private static IConfiguration? Configuration { get; set; }

    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        ServiceCollection = serviceCollection;
        Configuration = configuration;

        AddControlers();
        AddOpenApi();
        AddOptions();
        AddScoped();
        AddSingleton();
        AddSwaggerGen();
        AddToken();
        AddMySql();
        AddCors();
        AddRateLimit();
        SetApiData();

        return ServiceCollection;
    }

    private static void AddControlers()
    {
        ServiceCollection.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            options.SerializerSettings.Formatting = Formatting.Indented;
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
    }

    private static void AddOpenApi()
    {
        ServiceCollection.AddOpenApi();
    }

    private static void AddOptions()
    {
        ServiceCollection.AddOptions();
    }

    private static void AddScoped()
    {
        ServiceCollection.AddScoped<IUserService, UserService>();
        ServiceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
        ServiceCollection.AddScoped<ICustomerService, CustomerService>();
        ServiceCollection.AddScoped<IProductService, ProductService>();
        ServiceCollection.AddScoped<IOrderService, OrderService>();

        ServiceCollection.AddScoped<IUserRepository, UserRepository>();
        ServiceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
        ServiceCollection.AddScoped<IProductRepository, ProductRepository>();
        ServiceCollection.AddScoped<IOrderRepository, OrderRepository>();
        ServiceCollection.AddScoped<IOrderItemRepository, OrderItemRepository>();

        ServiceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        ServiceCollection.AddScoped<IApiDataService, ApiDataService>();
    }

    private static void AddSingleton()
    {
        var configure = new MapperConfiguration(config => { config.AddProfile(new MapperGeneric<string, string>()); });
        IMapper mapper = configure.CreateMapper();
        ServiceCollection.AddSingleton(mapper);
        ServiceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }

    private static void AddSwaggerGen()
    {
        OpenApiContact contact = new()
        {
            Name = "OutfitTrack",
            Url = new Uri("https://github.com/danibassetto")
        };

        ServiceCollection.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "OutfitTrack",
                Description = "Controle de condicionais (popularmente conhecido como 'malinha') de roupas e calçados.",
                Version = "v1",
                Contact = contact
            });

            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "JWT Authentication",
                Description = "Digitar somente JWT Bearer token",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            });

            x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            x.SchemaFilter<EnumSchemaFilter>();
        });

        ServiceCollection.AddSwaggerGenNewtonsoftSupport();
    }

    public static void AddToken()
    {
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        ServiceCollection.AddAuthentication((options) =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(c =>
        {
            c.RequireHttpsMetadata = false;
            c.SaveToken = true;
            c.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKeyJwt.Key)),
                ClockSkew = TimeSpan.Zero
            };
        });
    }

    private static void AddMySql()
    {
        var connectionString = Configuration!.GetConnectionString("DataBase");

        ServiceCollection.AddDbContext<OutfitTrackContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }

    private static void AddCors()
    {
        ServiceCollection.AddCors(options => options.AddPolicy("wasm", policy => policy.WithOrigins("http://localhost:3000").AllowAnyMethod().SetIsOriginAllowed(pol => true).AllowAnyHeader().AllowCredentials()));
    }

    private static void AddRateLimit()
    {
        ServiceCollection.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpcontext =>
            {
                var path = httpcontext.Request.Path.Value?.ToLower();

                if (path != null && (path.StartsWith("/api-docs") || path.StartsWith("/swagger") || path.StartsWith("/favicon.ico") || path.StartsWith("/scalar")))
                    return RateLimitPartition.GetNoLimiter("ScalarDocs");

                return RateLimitPartition.GetFixedWindowLimiter(partitionKey: httpcontext.Request.Headers.Host.ToString(),
                    factory: partition => new FixedWindowRateLimiterOptions
                    {
                        AutoReplenishment = true,
                        PermitLimit = 10,
                        QueueLimit = 2,
                        Window = TimeSpan.FromSeconds(10)
                    });
            });
        });
    }

    private static void SetApiData()
    {
        ApiData.SetMapper(new Application.Mapping.Mapper(new MapperConfiguration(config => { config.AddProfile(new MapperEntityOutput()); }).CreateMapper(), new MapperConfiguration(config => { config.AddProfile(new MapperInputEntity()); }).CreateMapper()));
    }
}