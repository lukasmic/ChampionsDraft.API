using Contracts;
using Core;
using Microsoft.Azure.Cosmos;

namespace Infrastructure.Cards;

public class CardRepository : ICardRepository
{
    private readonly Database _cardDatabase;
    private readonly Container _container;

    public CardRepository(AzureCosmosClient cosmosClient)
    {
        _cardDatabase = cosmosClient.Database;
        _container = _cardDatabase.GetContainer("Cards");
    }

    public async Task AddCard(Card card)
    {
        await _cardDatabase.CreateContainerIfNotExistsAsync("Cards", "/type");
        await _cardDatabase.GetContainer("Cards").CreateItemAsync(card);
    }

    public async Task AddCardsInBatch(IEnumerable<Card> cards)
    {
        await _cardDatabase.CreateContainerIfNotExistsAsync("Cards", "/type");
        var batch = _container.CreateTransactionalBatch(new PartitionKey("Card"));

        foreach (var card in cards)
        {
            batch.CreateItem(card);
        }

        var response = await batch.ExecuteAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Batch operation failed");
        }
    }
}
