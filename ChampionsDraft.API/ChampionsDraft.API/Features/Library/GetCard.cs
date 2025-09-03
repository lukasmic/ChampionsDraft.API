using Application.Interfaces;

namespace API.Features.Library;

public class GetCard : IMinimalEndpoint
{
    public static void MapEndpoint(RouteGroupBuilder heroRoute)
    {
        heroRoute.MapGet("/{id}", HandleAsync)
            .WithName("GetCardById")
            .WithSummary("Get a card by its ID");
    }

    internal static async Task<IResult> HandleAsync(ILibraryService cardDataService, string id)
    {
        var cards = await cardDataService.GetCardAsync(id);
        return Results.Ok(cards);
    }
}
