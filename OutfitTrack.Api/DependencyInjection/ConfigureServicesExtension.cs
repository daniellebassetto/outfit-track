using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using OutfitTrack.Domain.ApiManagement;
using OutfitTrack.Domain.Interfaces.Repository;
using OutfitTrack.Domain.Interfaces.Service;
using OutfitTrack.Domain.Mapping;
using OutfitTrack.Domain.Services;
using OutfitTrack.Infraestructure;
using OutfitTrack.Infraestructure.Repositories;
using System.Threading.RateLimiting;

namespace OutfitTrack.Api;

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
        AddTransient();
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

    private static void AddTransient()
    {
        ServiceCollection.AddTransient<ICustomerService, CustomerService>();
        ServiceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
        ServiceCollection.AddTransient<IProductService, ProductService>();
        ServiceCollection.AddTransient<IProductRepository, ProductRepository>();
        ServiceCollection.AddTransient<IOrderService, OrderService>();
        ServiceCollection.AddTransient<IOrderRepository, OrderRepository>();
        ServiceCollection.AddTransient<IOrderItemRepository, OrderItemRepository>();

        ServiceCollection.AddTransient<IApiDataService, ApiDataService>();
    }

    private static void AddScoped()
    {
        ServiceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
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
            x.SwaggerDoc("pt-br", new OpenApiInfo { Title = "OutfitTrack", Version = "pt-br", Contact = contact });
        });

        ServiceCollection.AddSwaggerGenNewtonsoftSupport();
        ServiceCollection.AddEndpointsApiExplorer();
    }

    private static void AddMySql()
    {
        var connectionString = Configuration!.GetConnectionString("DataBase");

        ServiceCollection.AddDbContext<OutfitTrackContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }

    private static void AddCors()
    {
        ServiceCollection.AddCors(options => options.AddPolicy("wasm", policy => policy.WithOrigins("adicionar rota do front").AllowAnyMethod().SetIsOriginAllowed(pol => true).AllowAnyHeader().AllowCredentials()));
    }

    private static void AddRateLimit()
    {
        ServiceCollection.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpcontext =>
                                    RateLimitPartition.GetFixedWindowLimiter(
                                                       partitionKey: httpcontext.Request.Headers.Host.ToString(),
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
        ApiData.SetMapper(new Domain.Mapping.Mapper(new MapperConfiguration(config => { config.AddProfile(new MapperEntityOutput()); }).CreateMapper(), new MapperConfiguration(config => { config.AddProfile(new MapperInputEntity()); }).CreateMapper()));
    }
}