using API;
using Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi()
                .AddCustomizableSocketsHttpHandler()
                .AddInfrastructureServices()
                .AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("ChampionsDraft API")
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
        //options.AddApiKeyAuthentication("apiKey", keyOptions => keyOptions.Value = "");
    });
}

app.UseHttpsRedirection();
app.AddEndpoints();

app.Run();
