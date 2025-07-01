namespace Domain;

public class Hero
{
    public Hero(Card card)
    {
        Name = card.Name;
        Code = card.Id;
        PackCode = card.PackCodes.First();
        ImageUrl = card.ImageUrl;

    }

    public Hero()
    {
    }

    public required string Name { get; init; }
    public required string Code { get; init; }
    public required string PackCode { get; init; }
    public string? ImageUrl { get; init; }
}
