using Application.Interfaces;
using Domain.Enums;

namespace API.Features.Draft;

public class CreateDraft : IMinimalEndpoint
{
    public static void MapEndpoint(RouteGroupBuilder draftRoute)
    {
        draftRoute.MapPost("/", CreateDraftHandler)
            .WithName("CreateDraft")
            .WithSummary("Create a draft");
    }

    private static async Task<IResult> CreateDraftHandler(IDraftService draftService, CreateDraftDTO createDraftDTO)
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
    }

    private class CreateDraftDTO
    {
        public required string Hero { get; set; }
        public required IEnumerable<Aspect> Aspects { get; set; }
        public IEnumerable<string>? DraftRules { get; set; }
    }
}
