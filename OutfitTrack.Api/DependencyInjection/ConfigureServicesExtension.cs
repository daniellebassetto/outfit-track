using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using OutfitTrack.Domain.ApiManagement;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;
using OutfitTrack.Domain.Interfaces.Service;
using OutfitTrack.Domain.Mapping;
using OutfitTrack.Domain.Services;
using OutfitTrack.Infraestructure;
using OutfitTrack.Infraestructure.Repository;

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
        AddAuthorization();
        AddOptions();
        AddTransient();
        AddSingleton();
        AddSwaggerGen();
        AddMySql();
        AddCors();
        SetApiData();

        return ServiceCollection;
    }

    private static void SetApiData()
    {
        ApiData.SetMapper(new Domain.Mapping.Mapper(new MapperConfiguration(config => { config.AddProfile(new MapperEntityOutput()); }).CreateMapper(), new MapperConfiguration(config => { config.AddProfile(new MapperInputEntity()); }).CreateMapper()));
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

    private static void AddAuthorization()
    {
        ServiceCollection.AddAuthorization();
    }

    private static void AddOptions()
    {
        ServiceCollection.AddOptions();
    }

    private static void AddTransient()
    {
        ServiceCollection.AddTransient<ICustomerService, CustomerService>();
        ServiceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
     
        ServiceCollection.AddTransient<IApiDataService, ApiDataService>();
    }

    private static void AddSingleton()
    {
        var configure = new MapperConfiguration(config =>
        {
            config.AddProfile(new MapperGeneric<string, string>());
        });
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
        ServiceCollection.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<OutfitTrackContext>();
    }

    private static void AddCors()
    {
        ServiceCollection.AddCors(options => options.AddPolicy("wasm", policy => policy.WithOrigins("adicionar rota do front").AllowAnyMethod().SetIsOriginAllowed(pol => true).AllowAnyHeader().AllowCredentials()));
    }
}