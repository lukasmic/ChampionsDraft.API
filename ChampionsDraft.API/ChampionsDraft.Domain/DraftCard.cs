namespace Domain;

public class DraftCard
{
    public Card Card { get; init; }
    private int AvailableAmount { get; set; }
    private double Weight { get; set; }

    DraftCard(Card card, double weight)
    {
        Card = card;
        AvailableAmount = card.DeckLimit;
        Weight = weight;
    }

    public double GetWeight()
    {
        return Weight;
    }

    public int GetAvailableAmount()
    {
        return AvailableAmount;
    }

    public static List<DraftCard> CreateDraftCards(List<Card> cards, Func<Card, double> weightFunc)
    {
        return cards.Select(card => new DraftCard(card, weightFunc(card))).ToList();
    }

    public int DecreaseAvailableAmount()
    {
        if (AvailableAmount <= 0)
        {
            throw new InvalidOperationException("No available amount left for this card.");
        }
        return AvailableAmount--;
    }
}