using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Infrastructure.Clients;

public class AzureCosmosClient
{
    private CosmosClient Client { get; }

    public AzureCosmosClient(SocketsHttpHandler socketsHttpHandler, IConfiguration configuration)
    {
        string connectionString = configuration.GetSection("CosmosDb:ConnectionString").Value
            ?? throw new ArgumentNullException(nameof(configuration), "CosmosDb connection string is not set in the configuration.");
        CosmosClientOptions cosmosClientOptions = new()
        {
            HttpClientFactory = () => new HttpClient(socketsHttpHandler, disposeHandler: false),
            UseSystemTextJsonSerializerWithOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreReadOnlyProperties = true
            },
            AllowBulkExecution = true
        };

        Client = new CosmosClient(connectionString, cosmosClientOptions);
    }

    public Database Database => Client.GetDatabase("ChampionsDraft");
}
