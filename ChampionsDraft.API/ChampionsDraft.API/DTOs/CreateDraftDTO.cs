using Domain.Enums;

namespace API.DTOs;

public class CreateDraftDTO
{
    public required string Hero { get; set; }
    public required IEnumerable<Aspect> Aspects { get; set; }
    public IEnumerable<string>? DraftRules { get; set; }
}
