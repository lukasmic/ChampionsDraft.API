using Application.Interfaces;
using Contracts;
using Domain;
using Domain.Enums;

namespace Application;

public class DraftService(ILibraryService libraryService, IDraftRepository draftRespository) : IDraftService
{
    private readonly ILibraryService _libraryService = libraryService;
    private readonly IDraftRepository _draftRespository = draftRespository;

    public async Task<Session> CreateDraftSessionAsync(string hero, IEnumerable<Aspect> aspects, IEnumerable<string> rules)
    {
        var cardPool = await _libraryService.GetCardsAsync();

        var session = Session.Create(hero, [.. cardPool]);
        _draftRespository.Add(session);

        return session;
    }

    public async Task<Session?> GetDraftSessionAsync(Guid sessionId)
    {
        var sessions = await _draftRespository.GetAll();
        return sessions.FirstOrDefault(s => s.Id == sessionId);
    }

    public async Task<List<DraftCard>> GetDraftOfferAsync(Guid sessionId, int count)
    {
        var sessions = await _draftRespository.GetAll();
        var session = sessions.FirstOrDefault(s => s.Id == sessionId);

        return session == null
            ? throw new InvalidOperationException("Draft session not found.")
            : session.GetDraftOffer(count);
    }
}
