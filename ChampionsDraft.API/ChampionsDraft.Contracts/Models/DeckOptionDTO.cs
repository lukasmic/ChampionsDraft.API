using System.Text.Json.Serialization;

namespace Contracts.Models;

public class DeckOptionDTO
{
    [JsonPropertyName("limit")]
    public int Limit { get; set; }

    [JsonPropertyName("trait")]
    public List<string> Trait { get; set; }

    [JsonPropertyName("type")]
    public List<string> Type { get; set; }

    [JsonPropertyName("name_limit")]
    public int? NameLimit { get; set; }

    [JsonPropertyName("use_deck_limit")]
    public bool? UseDeckLimit { get; set; }
}
