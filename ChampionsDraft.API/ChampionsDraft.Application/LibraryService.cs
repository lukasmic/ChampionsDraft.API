using Application.Interfaces;
using Contracts;
using Domain;

namespace Application;

public class LibraryService(ILibraryRepository libraryRepository, IMarvelCdbClient marvelCdbClient) : ILibraryService
{
    private readonly ILibraryRepository _libraryRepository = libraryRepository;
    private readonly IMarvelCdbClient _marvelCdbClient = marvelCdbClient;

    public async Task<IEnumerable<Card>> GetCardsAsync()
    {
        return await _libraryRepository.GetCardsAsync();
    }

    public async Task<Card> GetCardAsync(string id)
    {
        return await _libraryRepository.GetCardAsync(id);
    }

    public async Task<IEnumerable<Card>> CreateLibraryAsync()
    {
        var cards = await _marvelCdbClient.GetCardsAsync();

        var library = new List<Card>();
        var duplicateCards = new Dictionary<string, List<string>>();

        foreach (var card in cards)
        {
            if (card.FactionCode == "hero" || card.FactionCode == "campaign")
                continue;

            if (card.DuplicateOfCode is null)
            {
                library.Add(new Card
                {
                    Id = card.Code,
                    CardType = card.TypeName,
                    Name = card.Name,
                    Aspect = card.FactionName,
                    DeckLimit = card.DeckLimit,
                    Traits = card.Traits,
                    Cost = card.Cost,
                    MentalResources = card.ResourceMental,
                    EnergyResources = card.ResourceEnergy,
                    PhysicalResources = card.ResourcePhysical,
                    WildResources = card.ResourceWild,
                    PackCodes = new List<string> { card.PackCode },
                    ImageUrl = card.Imagesrc
                });
            }
            else
            {
                if (duplicateCards.TryAdd(card.DuplicateOfCode, new List<string> { card.PackCode }))
                    continue;
                else
                    duplicateCards[card.DuplicateOfCode].Add(card.PackCode);
            }
        }

        library.ForEach(card =>
        {
            var valuesToAdd = duplicateCards
                .Where(pair => pair.Key == card.Id)
                .SelectMany(pair => pair.Value)
                .Distinct()
                .ToList();

            card.PackCodes.AddRange(valuesToAdd);
        });

        await _libraryRepository.AddCardsInBatches(library);

        return library;
    }

    public async Task DeleteAllData()
    {
        await _libraryRepository.DeleteAllData();
    }
}
