namespace ChampionsDraft.API.Features.Draft;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Unconventional but intentional")]
public static class _DraftEndpoints
{
    public static WebApplication MapDraftEndpoints(this WebApplication app)
    {
        var draftRoute = app.MapGroup("/draft")
            .WithTags("Draft");

        CreateDraft.MapEndpoint(draftRoute);
        GetAllDrafts.MapEndpoint(draftRoute);
        GetDraft.MapEndpoint(draftRoute);
        GetDraftOffer.MapEndpoint(draftRoute);

        return app;
    }
}
