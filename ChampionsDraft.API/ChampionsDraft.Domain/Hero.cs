namespace Domain;

public class Hero
{
    public Hero(Card card)
    {
        Name = card.Name;
        Code = card.Id;
    }

    public required string Name { get; set; }
    public required string Code { get; set; }
}
