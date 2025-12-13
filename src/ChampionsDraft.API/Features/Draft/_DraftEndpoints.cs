namespace ChampionsDraft.API.Features.Draft;

public static class _DraftEndpoints
{
    public static WebApplication MapDraftEndpoints(this WebApplication app)
    {
        var draftRoute = app.MapGroup("/draft")
            .WithTags("Draft");

        CreateDraft.MapEndpoint(draftRoute);
        GetDraft.MapEndpoint(draftRoute);
        GetDraftOffer.MapEndpoint(draftRoute);

        return app;
    }
}
