using Contracts;
using Domain;
using Infrastructure.Cards;
using Microsoft.Azure.Cosmos;

namespace Infrastructure;

public class LibraryRepository : ILibraryRepository
{
    private readonly Database _cardDatabase;
    private readonly Container _container;
    private List<Card> _cards = new List<Card>();

    // Batch capacity for transactional batch operations. Cosmos DB supports a maximum of 100 operations per batch.
    const int BatchCapacity = 100;

    public LibraryRepository(AzureCosmosClient cosmosClient)
    {
        _cardDatabase = cosmosClient.Database;
        _container = _cardDatabase.GetContainer("Cards");
    }

    public async Task<Card> GetCardAsync(string id)
    {
        if (_cards.Count == 0)
        {
            await Instantiate();
        }

        var card = _cards.FirstOrDefault(c => c.Id == id);
        if (card != null)
        {
            return card;
        }

        throw new KeyNotFoundException($"Card with ID {id} not found.");
    }

    public async Task<IEnumerable<Card>> GetCardsAsync()
    {
        return _cards.Count > 0
            ? _cards
            : await Instantiate();
    }

    public async Task AddCardsInBatches(IEnumerable<Card> cards)
    {
        await _cardDatabase.CreateContainerIfNotExistsAsync("Cards", "/type");
        var batch = _container.CreateTransactionalBatch(new PartitionKey("Card"));

        var batchSize = 0;
        var batchIteration = 1;

        // Execute the batch in chunks of BatchCapacity
        foreach (var card in cards)
        {
            batch.CreateItem(card);
            batchSize++;

            if (batchSize == BatchCapacity)
            {
                var response = await batch.ExecuteAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Batch operation failed");
                }

                batchSize = 0;
                batchIteration++;
            }
        }

        // Execute any remaining items in the batch
        if (batchSize > 0)
        {
            var response = await batch.ExecuteAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Batch operation failed");
            }
        }

        _cards.AddRange(cards);
    }

    public async Task DeleteAllData()
    {
        await _container.DeleteContainerAsync();
        _cards.Clear();
    }

    public async Task AddCard(Card card)
    {
        await _cardDatabase.CreateContainerIfNotExistsAsync("Cards", "/type");
        await _cardDatabase.GetContainer("Cards").CreateItemAsync(card);

        _cards.Add(card);
    }

    private async Task<List<Card>> Instantiate()
    {
        await _cardDatabase.CreateContainerIfNotExistsAsync("Cards", "/type");

        var query = new QueryDefinition("SELECT * FROM Cards");
        var iterator = _container.GetItemQueryIterator<Card>(query);
        var cards = new List<Card>();
        while (iterator.HasMoreResults)
        {
            var response = await iterator.ReadNextAsync();
            cards.AddRange(response);
        }

        return _cards = cards;
    }
}
