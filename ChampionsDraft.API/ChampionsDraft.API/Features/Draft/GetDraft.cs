using Application.Interfaces;

namespace API.Features.Draft;

public class GetDraft : IMinimalEndpoint
{
    public static void MapEndpoint(RouteGroupBuilder draftRoute)
    {
        draftRoute.MapGet("/{draftId}", HandleAsync)
            .WithName("GetDraft")
            .WithSummary("Get a draft by ID");
    }

    private static async Task<IResult> HandleAsync(IDraftService draftService, Guid draftId)
    {
        var draft = await draftService.GetDraftAsync(draftId);

        if (draft == null)
        {
            return Results.NotFound($"Draft session with {draftId} not found.");
        }

        return Results.Ok(GetDraftDTO.FromDraft(draft));
    }

    private class GetDraftDTO
    {
        public required string DraftId { get; set; }
        public required string Hero { get; set; }

        public static GetDraftDTO FromDraft(Domain.Draft draft)
        {
            return new GetDraftDTO
            {
                DraftId = draft.Id.ToString(),
                Hero = draft.Hero
            };
        }
    }
}
