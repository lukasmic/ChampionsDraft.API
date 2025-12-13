using ChampionsDraft.Application.Interfaces;

namespace ChampionsDraft.API.Features.Library;

public class CreateLibrary : IMinimalEndpoint
{
    public static void MapEndpoint(RouteGroupBuilder heroRoute)
    {
        heroRoute.MapPost("/", HandleAsync)
            .WithName("Create")
            .WithSummary("Create a card library");
    }

    public static async Task<IResult> HandleAsync(ILibraryService cardDataService)
    {
        var cards = await cardDataService.CreateLibraryAsync();
        return Results.Ok(cards);
    }
}
