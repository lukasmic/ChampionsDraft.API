using System.Text.Json.Serialization;

namespace ChampionsDraft.Contracts.Models;

public class MetaDTO
{
    [JsonPropertyName("colors")]
    public List<string> Colors { get; set; }

    [JsonPropertyName("offset")]
    public string Offset { get; set; }
}
