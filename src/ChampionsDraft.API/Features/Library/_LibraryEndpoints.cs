namespace ChampionsDraft.API.Features.Library;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Unconventional but intentional")]
public static class _LibraryEndpoints
{
    public static WebApplication MapLibraryEndpoints(this WebApplication app)
    {
        var route = app.MapGroup("/cards")
            .WithTags("Library");

        CreateLibrary.MapEndpoint(route);
        GetAllCards.MapEndpoint(route);
        GetCard.MapEndpoint(route);
        DeleteLibrary.MapEndpoint(route);

        return app;
    }
}
