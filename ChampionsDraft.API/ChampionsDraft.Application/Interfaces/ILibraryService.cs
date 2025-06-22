using Domain;

namespace Application.Interfaces;
public interface ILibraryService
{
    Task<IEnumerable<Card>> GetCardsAsync();
    Task<Card> GetCardAsync(string id);
    Task<IEnumerable<Card>> CreateLibraryAsync();
    Task DeleteAllData();
}
