namespace API.Features.Heroes;

public static class _HeroesEndpoints
{
    public static WebApplication MapHeroesEndpoints(this WebApplication app)
    {
        var route = app.MapGroup("/heroes")
            .WithTags("Heroes")
            .WithOpenApi();

        GetAllHeroes.MapEndpoint(route);
        GetRandomHeroes.MapEndpoint(route);

        return app;
    }
}
