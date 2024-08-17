using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OutfitTrack.Api;
using OutfitTrack.Domain.Entities;

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

app.UseAuthorization();

app.MapGroup("auth").MapIdentityApi<User>().WithTags("Authorization");

app.MapPost("auth/logout", async ([FromServices] SignInManager<User> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Ok();
}).RequireAuthorization().WithTags("Authorization");

app.MapControllers();

app.Run();