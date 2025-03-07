using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using OutfitTrack.Application.ApiManagement;
using OutfitTrack.Application.Interfaces;
using OutfitTrack.Application.Mapping;
using OutfitTrack.Application.Services;
using OutfitTrack.Domain.Interfaces;
using OutfitTrack.Infraestructure;
using OutfitTrack.Infraestructure.Repositories;
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
        AddOptions();
        AddScoped();
        AddSingleton();
        AddSwaggerGen();
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

    private static void AddOptions()
    {
        ServiceCollection.AddOptions();
    }

    private static void AddScoped()
    {
        ServiceCollection.AddScoped<ICustomerService, CustomerService>();
        ServiceCollection.AddScoped<IProductService, ProductService>();
        ServiceCollection.AddScoped<IOrderService, OrderService>();

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
        });

        ServiceCollection.AddSwaggerGenNewtonsoftSupport();
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
                                    RateLimitPartition.GetFixedWindowLimiter(partitionKey: httpcontext.Request.Headers.Host.ToString(),
                                    factory: partition => new FixedWindowRateLimiterOptions
                                    {
                                        AutoReplenishment = true,
                                        PermitLimit = 2,
                                        QueueLimit = 0,
                                        Window = TimeSpan.FromSeconds(5)
                                    }));
        });
    }

    private static void SetApiData()
    {
        ApiData.SetMapper(new Application.Mapping.Mapper(new MapperConfiguration(config => { config.AddProfile(new MapperEntityOutput()); }).CreateMapper(), new MapperConfiguration(config => { config.AddProfile(new MapperInputEntity()); }).CreateMapper()));
    }
}