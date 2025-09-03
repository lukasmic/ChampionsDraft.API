using Application.Interfaces;

namespace API.Features.Library;

public class GetAllCards : IMinimalEndpoint
{
    public static void MapEndpoint(RouteGroupBuilder heroRoute)
    {
        heroRoute.MapGet("/", HandleAsync)
            .WithName("GetAll")
            .WithSummary("Get all cards in the library");
    }

    internal static async Task<IResult> HandleAsync(ILibraryService cardDataService)
    {
        var cards = await cardDataService.GetCardsAsync();
        return Results.Ok(cards);
    }
}
