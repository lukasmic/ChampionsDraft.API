using Domain;

namespace API.DTOs;

public class GetDraftDTO
{
    public required string DraftId { get; set; }
    public required string Hero { get; set; }

    public static GetDraftDTO FromDraft(Draft draft)
    {
        return new GetDraftDTO
        {
            DraftId = draft.Id.ToString(),
            Hero = draft.Hero
        };
    }
}
