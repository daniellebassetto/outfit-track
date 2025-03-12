using OutfitTrack.CrossCutting.Ioc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDependencyInjection(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "OutfitTrack - v1");
    x.InjectStylesheet("/swagger-ui/SwaggerDark.css");
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseStaticFiles();

app.UseCors("wasm");

app.UseRouting();

app.UseAuthorization();

app.UseRateLimiter();

app.MapControllers();

app.Run();
