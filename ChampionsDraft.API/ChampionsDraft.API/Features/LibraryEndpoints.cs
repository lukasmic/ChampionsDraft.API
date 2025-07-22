using Application.Interfaces;

namespace API.Features;

public static class LibraryEndpoints
{
    public static WebApplication MapLibraryEndpoints(this WebApplication app)
    {
        var route = app.MapGroup("/cards")
            .WithTags("Library")
            .WithOpenApi();
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
        .WithName("Create")
        .WithSummary("Create a card library");

        route.MapGet("/", async (ILibraryService cardDataService) =>
        {
            var cards = await cardDataService.GetCardsAsync();
            return Results.Ok(cards);
        })
        .WithName("GetAll")
        .WithSummary("Get all cards in the library");

        route.MapGet("/{id}", async (ILibraryService cardDataService, string id) =>
        {
            var cards = await cardDataService.GetCardAsync(id);
            return Results.Ok(cards);
        })
        .WithName("GetCardById")
        .WithSummary("Get a card by its ID");

        route.MapDelete("/", async (ILibraryService cardDataService) =>
        {
            await cardDataService.DeleteAllData();
            return Results.NoContent();
        })
        .WithName("Delete")
        .WithSummary("Delete all data in the library");
    }
}
