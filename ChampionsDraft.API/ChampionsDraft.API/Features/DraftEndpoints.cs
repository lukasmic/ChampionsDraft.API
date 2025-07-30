using API.DTOs;
using Application.Interfaces;

namespace API.Features;

public static class DraftEndpoints
{
    public static WebApplication MapDraftEndpoints(this WebApplication app)
    {
        var draftRoute = app.MapGroup("/draft")
            .WithTags("Draft")
            .WithOpenApi();
        MapEndpoints(draftRoute);

        return app;
    }

    private static void MapEndpoints(RouteGroupBuilder draftRoute)
    {
        draftRoute.MapPost("/", async (IDraftService draftService, CreateDraftDTO createDraftDTO) =>
        {
            if (createDraftDTO == null)
            {
                return Results.BadRequest("Draft data cannot be null.");
            }

            var draft = await draftService.CreateDraftAsync(
                createDraftDTO.Hero,
                createDraftDTO.Aspects,
                createDraftDTO.DraftRules ?? []
            );

            return Results.Created($"/draft/{draft.Id}", draft.Id);
        })
            .WithName("CreateDraft")
            .WithSummary("Create a draft");

        draftRoute.MapGet("/{draftId}", async (IDraftService draftService, Guid draftId) =>
        {
            var draft = await draftService.GetDraftAsync(draftId);

            if (draft == null)
            {
                return Results.NotFound($"Draft session with {draftId} not found.");
            }

            return Results.Ok(GetDraftDTO.FromDraft(draft));
        })
            .WithName("GetDraft")
            .WithSummary("Get a draft by ID");

        draftRoute.MapGet("/{draftId}/offer", async (IDraftService draftService, Guid draftId, int count) =>
        {
            // Uncomment and implement this method when needed
            var offer = await draftService.GetOfferAsync(draftId, count);
            return Results.Ok(offer.Select(x => x.Card));
        })
            .WithName("GetDraftOffer")
            .WithSummary("Get a draft offer");
    }
}
