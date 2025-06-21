using API;
using API.Features;
using Application.Interfaces;
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

app.MapGet("/cards/{id}", async (ICardLibraryService cardDataService, string id) =>
{
    var result = await cardDataService.GetCards();
    var card = result.Where(card => card.Code == id);
    return Results.Ok(card);
})
.WithName("Retrieve card");

app.MapHeroesEndpoints();
app.MapDraftEndpoints();

app.Run();
