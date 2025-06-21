using Application.Interfaces;
using Contracts;
using Contracts.Models;
using Domain;

namespace Application;

public class CardLibraryService(ICardRepository cardRepository, IMarvelCdbClient marvelCdbClient) : ICardLibraryService
{
    private readonly ICardRepository _cardRepository = cardRepository;
    private readonly IMarvelCdbClient _marvelCdbClient = marvelCdbClient;

    public async Task CreateCard(string id)
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

    public async Task<IEnumerable<CardDTO>> GetCards()
    {
        return await _marvelCdbClient.GetCards();
    }
}
