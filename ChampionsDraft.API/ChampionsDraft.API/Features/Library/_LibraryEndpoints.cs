namespace API.Features.Library;

public static class _LibraryEndpoints
{
    public static WebApplication MapLibraryEndpoints(this WebApplication app)
    {
        var route = app.MapGroup("/cards")
            .WithTags("Library")
            .WithOpenApi();

        CreateLibrary.MapEndpoint(route);
        GetAllCards.MapEndpoint(route);
        GetCard.MapEndpoint(route);
        DeleteLibrary.MapEndpoint(route);

        return app;
    }
}
