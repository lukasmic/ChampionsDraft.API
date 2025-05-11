using System.Text.Json.Serialization;

namespace Contracts.Models;

public class MetaDTO
{
    [JsonPropertyName("colors")]
    public List<string> Colors { get; set; }

    [JsonPropertyName("offset")]
    public string Offset { get; set; }
}
