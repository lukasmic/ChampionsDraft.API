using Application.Interfaces;

namespace API.Features.Library;

public class CreateLibrary : IMinimalEndpoint
{
    public static void MapEndpoint(RouteGroupBuilder heroRoute)
    {
        heroRoute.MapPost("/", HandleAsync)
            .WithName("Create")
            .WithSummary("Create a card library");
    }

    internal static async Task<IResult> HandleAsync(ILibraryService cardDataService)
    {
        var cards = await cardDataService.CreateLibraryAsync();
        return Results.Ok(cards);
    }
}
