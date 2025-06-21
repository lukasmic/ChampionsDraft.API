using Domain;

namespace Contracts;

public interface ICardRepository
{
    Task AddCard(Card card);
    Task AddCardsInBatch(IEnumerable<Card> cards);
}
