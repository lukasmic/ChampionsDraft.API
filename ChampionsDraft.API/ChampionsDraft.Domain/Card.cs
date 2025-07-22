namespace Domain;

public class Card
{
    public required string Id { get; set; }
    public string Type { get; init; } = "Card";
    public required string CardType { get; init; }
    public required string Name { get; init; }
    public required string Aspect { get; init; }
    public required int DeckLimit { get; init; }

    public required string Traits { get; init; }
    public required string Effect { get; init; }
    public required int Cost { get; init; }
    public int? MentalResources { get; init; }
    public int? EnergyResources { get; init; }
    public int? PhysicalResources { get; init; }
    public int? WildResources { get; init; }

    public List<string> PackCodes { get; set; } = [];
    public string? ImageUrl { get; set; }
}
