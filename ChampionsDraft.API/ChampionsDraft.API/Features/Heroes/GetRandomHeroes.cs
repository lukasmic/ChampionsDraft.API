using Application.Interfaces;

namespace API.Features.Heroes;

public class GetRandomHeroes : IMinimalEndpoint
{
    public static void MapEndpoint(RouteGroupBuilder heroRoute)
    {
        heroRoute.MapGet("/{choiceCount}", HandleAsync)
            .WithName("Get random heroes")
            .WithSummary("Get a list of random heroes based on the specified choice count");
    }

    private static async Task<IResult> HandleAsync(IHeroService heroService, int choiceCount)
    {
        return Results.Ok(await heroService.GetRandomHeroesAsync(choiceCount));
    }
}
