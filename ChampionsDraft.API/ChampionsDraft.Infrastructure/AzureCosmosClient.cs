using Microsoft.Azure.Cosmos;
using System;

namespace ChampionsDraft.Infrastructure;

public class AzureCosmosClient
{
    private CosmosClient Client { get; }

    public AzureCosmosClient(SocketsHttpHandler socketsHttpHandler, string connectionString, CosmosClientOptions options)
    {
        CosmosClientOptions cosmosClientOptions = new CosmosClientOptions()
        {
            HttpClientFactory = () => new HttpClient(socketsHttpHandler, disposeHandler: false)
        };

        Client = new CosmosClient(connectionString, cosmosClientOptions);
    }

    public Database GetDatabase(string databaseId)
    {
        return Client.GetDatabase(databaseId);
    }
}
