using Contracts;
using Core;

namespace Application;

public class CardLibraryService(ICardRepository cardRepository) : ICardLibraryService
{
    private readonly ICardRepository _cardRepository = cardRepository;

    public async Task CreateCardLibrary()
    {
        await CreateCard();
    }

    public async Task CreateCard()
    {
        var card = new Card
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Test Card",
            Aspect = "Basic"
        };
        await _cardRepository.AddCard(card);
    }

    public async Task AddCardsInBatch()
    {
        var cards = new List<Card>()
        {
            new() {
                Id = Guid.NewGuid().ToString(),
                Name = "Test Card 1",
                Aspect = "Basic"
            },
            new() {
                Id = Guid.NewGuid().ToString(),
                Name = "Test Card 2",
                Aspect = "Basic"
            },
            new() {
                Id = Guid.NewGuid().ToString(),
                Name = "Test Card 3",
                Aspect = "Basic"
            }
        };
        await _cardRepository.AddCardsInBatch(cards);
    }
}
