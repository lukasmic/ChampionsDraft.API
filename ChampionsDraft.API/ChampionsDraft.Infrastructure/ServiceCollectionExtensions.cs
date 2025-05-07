using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<AzureCosmosClient>();
        services.AddScoped<ICardRepository, CardRepository>();
        return services;
    }
}
