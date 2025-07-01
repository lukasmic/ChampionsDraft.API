using Application.Interfaces;

namespace API.Features;

public static class HeroesEndpoints
{
    public static WebApplication MapHeroesEndpoints(this WebApplication app)
    {
        var route = app.MapGroup("/heroes")
            .WithTags("Heroes")
            .WithOpenApi()
            .WithSummary("Hero endpoints");
        route.MapEndpoints();

        return app;
    }

    private static void MapEndpoints(this RouteGroupBuilder route)
    {
        route.MapGet("/", async (IHeroService heroService) =>
        {
            return Results.Ok(await heroService.GetAllHeroesAsync());
        })
        .WithName("Get all heroes");

        route.MapGet("/{choiceCount}", async (IHeroService heroService, int choiceCount) =>
        {
            return Results.Ok(await heroService.GetRandomHeroesAsync(choiceCount));
        })
        .WithName("Get a random choice of requested heroes");
    }
}
