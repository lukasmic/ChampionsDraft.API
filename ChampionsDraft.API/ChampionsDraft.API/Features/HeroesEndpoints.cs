using Application.Interfaces;

namespace API.Features;

public static class HeroesEndpoints
{
    public static WebApplication MapHeroesEndpoints(this WebApplication app)
    {
        var route = app.MapGroup("/heroes")
            .WithTags("Heroes")
            .WithOpenApi();
        route.MapEndpoints();

        return app;
    }

    private static void MapEndpoints(this RouteGroupBuilder route)
    {
        route.MapGet("/", async (IHeroService heroService) =>
        {
            return Results.Ok(await heroService.GetAllHeroesAsync());
        })
            .WithName("Get all heroes")
            .WithSummary("Get a list of all heroes");

        route.MapGet("/{choiceCount}", async (IHeroService heroService, int choiceCount) =>
        {
            return Results.Ok(await heroService.GetRandomHeroesAsync(choiceCount));
        })
            .WithName("Get random heroes")
            .WithSummary("Get a list of random heroes based on the specified choice count");
    }
}
