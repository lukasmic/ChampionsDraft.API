namespace Application;
public interface ICardLibraryService
{
    Task CreateCard(string id);
    Task AddCardsInBatch();
}
