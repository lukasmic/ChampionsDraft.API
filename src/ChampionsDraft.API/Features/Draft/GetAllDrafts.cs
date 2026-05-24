using ChampionsDraft.Application.Interfaces;

namespace ChampionsDraft.API.Features.Draft;

public class GetAllDrafts : IMinimalEndpoint
{
    public static void MapEndpoint(RouteGroupBuilder draftRoute)
    {
        draftRoute.MapGet("", HandleAsync)
            .WithName("GetAllDrafts")
            .WithSummary("Get all drafts");
    }

    private static async Task<IResult> HandleAsync(IDraftService draftService)
    {
        var drafts = await draftService.GetAllDraftsAsync();

        if (drafts is null)
        {
            return Results.NotFound("Null draft array");
        }

        return Results.Ok(GetAllDraftsDTO.FromDrafts(drafts.ToList()));
    }

    private class GetAllDraftsDTO
    {
        public required string DraftId { get; set; }
        public required string Hero { get; set; }

        public static List<GetAllDraftsDTO> FromDrafts(List<Domain.Draft> draft)
        {
            return draft.Select(d => new GetAllDraftsDTO
            {
                DraftId = d.Id.ToString(),
                Hero = d.Hero
            }).ToList();
        }
    }
}
