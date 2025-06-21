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
        route.MapGet("/", async (ICardLibraryService cardDataService) =>
        {
            var result = await cardDataService.GetCards();
            var heroes = result.Where(card => card.TypeName == "Hero")
                .Select(hero => hero.Name).Distinct();
            return Results.Ok(heroes);
        })
        .WithName("Retrieve heroes");
    }
}
