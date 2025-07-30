using Application.Interfaces;
using Contracts;
using Domain;
using Domain.Enums;

namespace Application;

public class DraftService(ILibraryService libraryService, IDraftRepository draftRespository) : IDraftService
{
    private readonly ILibraryService _libraryService = libraryService;
    private readonly IDraftRepository _draftRespository = draftRespository;

    public async Task<Draft> CreateDraftAsync(string hero, IEnumerable<Aspect> aspects, IEnumerable<string> rules)
    {
        var cardPool = await _libraryService.GetCardsAsync();

        var draft = Draft.Create(hero, [.. cardPool]);
        _draftRespository.Add(draft);

        return draft;
    }

    public async Task<Draft?> GetDraftAsync(Guid draftId)
    {
        var drafts = await _draftRespository.GetAll();
        return drafts.FirstOrDefault(s => s.Id == draftId);
    }

    public async Task<List<DraftCard>> GetOfferAsync(Guid draftId, int count)
    {
        var drafts = await _draftRespository.GetAll();
        var draft = drafts.FirstOrDefault(s => s.Id == draftId);

        return draft == null
            ? throw new InvalidOperationException("Draft not found.")
            : draft.GetDraftOffer(count);
    }
}
