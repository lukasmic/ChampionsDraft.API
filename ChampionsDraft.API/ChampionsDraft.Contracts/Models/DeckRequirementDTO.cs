using System.Text.Json.Serialization;

namespace Contracts.Models;

public class DeckRequirementDTO
{
    [JsonPropertyName("aspects")]
    public int Aspects { get; set; }

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }
}
