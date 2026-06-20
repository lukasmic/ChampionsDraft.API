namespace ChampionsDraft.API.Features.Heroes;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Unconventional but intentional")]
public static class _HeroesEndpoints
{
    public static WebApplication MapHeroesEndpoints(this WebApplication app)
    {
        var route = app.MapGroup("/heroes")
            .WithTags("Heroes");

        GetAllHeroes.MapEndpoint(route);
        GetRandomHeroes.MapEndpoint(route);

        return app;
    }
}
