using OutfitTrack.CrossCutting.Ioc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDependencyInjection(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "OutfitTrack - v1");
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("wasm");

app.UseRouting();

app.UseRateLimiter();

app.MapControllers();

app.Run();