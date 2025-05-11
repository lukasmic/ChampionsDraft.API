using API;
using Application;
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

app.MapPost("/cards", async (ICardLibraryService cardDataService) =>
{
    await cardDataService.AddCardsInBatch();
    return Results.Created();
})
.WithName("Create card library");

app.MapPost("/cards/{id}", async (ICardLibraryService cardDataService, string id) =>
{
    await cardDataService.CreateCard(id);
    return Results.Created();
})
.WithName("Create card");

app.MapGet("/cards", async (ICardLibraryService cardDataService) =>
{
    var result = await cardDataService.GetCards();
    var heroes = result.Where(card => card.TypeName == "Hero");
    return Results.Ok(heroes);
})
.WithName("Retrieve cards");

app.Run();
