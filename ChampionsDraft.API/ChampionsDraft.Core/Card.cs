namespace Core;

public class Card
{
    public required string Id { get; set; }
    public string Type { get; init; } = "Card";
    public required string Name { get; set; }
    public required string Aspect { get; set; }
}
