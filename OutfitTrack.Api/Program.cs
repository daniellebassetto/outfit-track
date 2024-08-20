using OutfitTrack.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDependencyInjection(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/pt-br/swagger.json", "OutfitTrack");
    });
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("wasm");

app.UseRouting();

app.UseRateLimiter();

app.MapControllers();

app.Run();