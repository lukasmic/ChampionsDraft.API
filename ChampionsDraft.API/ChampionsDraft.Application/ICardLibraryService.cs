namespace Application;
public interface ICardLibraryService
{
    Task CreateCard();
    Task AddCardsInBatch();
}
