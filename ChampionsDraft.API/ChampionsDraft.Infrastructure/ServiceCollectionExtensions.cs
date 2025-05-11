using Contracts;
using Infrastructure.Cards;
using Infrastructure.MarvelCDB;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<AzureCosmosClient>();
        services.AddSingleton<IMarvelCdbClient, MarvelCdbClient>();
        services.AddScoped<ICardRepository, CardRepository>();
        return services;
    }
}
