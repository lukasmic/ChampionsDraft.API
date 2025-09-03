using Application.Interfaces;

namespace API.Features.Heroes;

public class GetAllHeroes : IMinimalEndpoint
{
    public static void MapEndpoint(RouteGroupBuilder heroRoute)
    {
        heroRoute.MapGet("/", HandleAsync)
            .WithName("Get all heroes")
            .WithSummary("Get a list of all heroes");
    }

    private static async Task<IResult> HandleAsync(IHeroService heroService)
    {
        return Results.Ok(await heroService.GetAllHeroesAsync());
    }
}
