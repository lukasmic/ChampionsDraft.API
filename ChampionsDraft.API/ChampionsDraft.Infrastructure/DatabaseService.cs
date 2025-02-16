using ChampionsDraft.Core;

namespace ChampionsDraft.Infrastructure;

public class DatabaseService
{
    private readonly AzureCosmosClient _cosmosClient;

    public DatabaseService(AzureCosmosClient cosmosClient)
    {
        _cosmosClient = cosmosClient;
        _cosmosClient.GetDatabase("ChampionsDraft").CreateContainerIfNotExistsAsync("Cards", "/id");
    }

    public void AddCard()
    {
        var card = new Card() { Id = 1, Name = "First"};
        _cosmosClient.GetDatabase("ChampionsDraft").GetContainer("Cards").CreateItemAsync(card);
    }
}
