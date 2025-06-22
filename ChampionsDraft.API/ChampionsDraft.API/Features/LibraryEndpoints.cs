using Application.Interfaces;

namespace API.Features;

public static class LibraryEndpoints
{
    public static WebApplication MapLibraryEndpoints(this WebApplication app)
    {
        var route = app.MapGroup("/cards")
            .WithTags("library")
            .WithOpenApi()
            .WithSummary("Card library pool");
        route.MapEndpoints();

        return app;
    }

    private static void MapEndpoints(this RouteGroupBuilder route)
    {
        route.MapPost("/", async (ILibraryService cardDataService) =>
        {
            var cards = await cardDataService.CreateLibraryAsync();
            return Results.Ok(cards);
        })
        .WithName("Create card library pool");

        route.MapGet("/", async (ILibraryService cardDataService) =>
        {
            var cards = await cardDataService.GetCardsAsync();
            return Results.Ok(cards);
        })
        .WithName("Get all cards");

        route.MapGet("/{id}", async (ILibraryService cardDataService, string id) =>
        {
            var cards = await cardDataService.GetCardAsync(id);
            return Results.Ok(cards);
        })
        .WithName("Get a card by ID");

        route.MapDelete("/", async (ILibraryService cardDataService) =>
        {
            await cardDataService.DeleteAllData();
            return Results.NoContent();
        })
        .WithName("Delete all cards");
    }
}
