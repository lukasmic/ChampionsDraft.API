using Contracts;
using Contracts.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Infrastructure.Clients;
internal class MarvelCdbClient : IMarvelCdbClient
{
    private readonly HttpClient _httpClient;
    public MarvelCdbClient(IConfiguration configuration)
    {
        var baseUrl = configuration.GetSection("MarvelCdb:ApiUrl").Value
            ?? throw new ArgumentNullException(nameof(configuration), "Base URL is not set in the configuration.");
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
    }

    public async Task<IEnumerable<CardDTO>> GetCardsAsync()
    {
        var response = await _httpClient.GetAsync("cards");
        response.EnsureSuccessStatusCode();
        var cards = await response.Content.ReadFromJsonAsync<IEnumerable<CardDTO>>();
        return cards ?? throw new InvalidOperationException("The response content is null or invalid.");
    }
}
