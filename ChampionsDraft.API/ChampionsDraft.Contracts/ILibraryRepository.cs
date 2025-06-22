using Domain;

namespace Contracts;

public interface ILibraryRepository
{
    Task<Card> GetCardAsync(string id);
    Task<IEnumerable<Card>> GetCardsAsync();
    Task AddCardsInBatches(IEnumerable<Card> cards);
    Task AddCard(Card card);
    Task DeleteAllData();
}