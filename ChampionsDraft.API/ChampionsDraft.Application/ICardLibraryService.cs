using Contracts.Models;

namespace Application;
public interface ICardLibraryService
{
    Task CreateCard(string id);
    Task AddCardsInBatch();
    Task<IEnumerable<CardDTO>> GetCards();
}
