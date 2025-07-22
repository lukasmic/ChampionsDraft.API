namespace Domain;

public class Session
{
    public Guid Id { get; } = Guid.CreateVersion7();
    public string Hero { get; }
    private DateTime CreatedAt { get; } = DateTime.UtcNow;
    private DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    private IEnumerable<DraftRule>? Rules { get; }
    private List<DraftCard> Pool { get; set; } = new List<DraftCard>();
    private double PoolWeight { get; set; }
    private List<DraftCard> OfferedCards { get; set; } = new List<DraftCard>();
    private List<Card> Deck { get; set; } = new List<Card>();
    private SessionStatus Status { get; set; } = SessionStatus.Started;
    private int DeckSize => Deck.Count;

    private Session(string hero, IEnumerable<DraftRule>? rules, List<DraftCard> pool, double poolWeight)
    {
        Hero = hero;
        Rules = rules;
        Pool = pool;
        PoolWeight = poolWeight;
        Status = SessionStatus.InProgress;
    }

    public static Session Create(string hero, List<Card> cardPool, IEnumerable<DraftRule>? rules = null)
    {
        if (string.IsNullOrWhiteSpace(hero))
        {
            throw new ArgumentException("Hero cannot be null or empty.", nameof(hero));
        }

        if (cardPool == null || cardPool.Count == 0)
        {
            throw new ArgumentException("Card pool cannot be null or empty.", nameof(cardPool));
        }

        var pool = DraftCard.CreateDraftCards(cardPool, card => card.DeckLimit > 0 ? 1.0 : 0);
        var poolWeight = pool.Sum(card => card.GetWeight());

        return new Session(hero, rules, pool, poolWeight);
    }

    public List<DraftCard> GetDraftOffer(int choiceCount)
    {
        if (Status != SessionStatus.InProgress)
        {
            throw new InvalidOperationException("Session is not in progress.");
        }

        return SelectCardsWithWeights(choiceCount);
    }

    private List<DraftCard> SelectCardsWithWeights(int count)
    {
        OfferedCards.Clear();
        var random = new Random();

        for (int i = 0; i < count && Pool.Count > 0; i++)
        {
            // Select a random value between 0 and total weight  
            double randomValue = random.NextDouble() * PoolWeight;

            // Find the card that corresponds to this random value  
            double accumulatedWeight = 0;
            DraftCard? selectedCard = null;

            foreach (var card in Pool)
            {
                accumulatedWeight += card.GetWeight();
                if (accumulatedWeight >= randomValue)
                {
                    selectedCard = card;
                    break;
                }
            }

            // If somehow we didn't select a card (shouldn't happen), take the first one  
            if (selectedCard == null && Pool.Count > 0)
                selectedCard = Pool[0];

            OfferedCards.Add(selectedCard);
        }

        return OfferedCards;
    }

    //public List<Card> SelectCard(List<DraftCard> selectedCards)
    //{

    //    // Add selected card to result and remove from temp pool to avoid duplicates in pack  
    //    OfferedCards.Add(selectedCard);
    //    if (selectedCard.DecreaseAvailableAmount() == 0)
    //    {
    //        pool.Remove(selectedCard);
    //        PoolWeight -= selectedCard.GetWeight;
    //    }

    //    // Check if new card pool has the selected card updated
    //}

    private enum SessionStatus
    {
        Started,
        InProgress,
        Completed
    }
}


