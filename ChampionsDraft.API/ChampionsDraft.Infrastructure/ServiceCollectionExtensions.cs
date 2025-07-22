using Contracts;
using Infrastructure.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<AzureCosmosClient>();
        services.AddSingleton<IMarvelCdbClient, MarvelCdbClient>();
        services.AddSingleton<ILibraryRepository, LibraryRepository>();
        services.AddSingleton<IDraftRepository, DraftRepository>();
        return services;
    }
}
