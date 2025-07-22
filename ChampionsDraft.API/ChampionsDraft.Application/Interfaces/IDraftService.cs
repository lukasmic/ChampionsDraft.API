using Domain;
using Domain.Enums;

namespace Application.Interfaces;

public interface IDraftService
{
    Task<Session> CreateDraftSessionAsync(string hero, IEnumerable<Aspect> aspects, IEnumerable<string> rules);
    Task<Session?> GetDraftSessionAsync(Guid sessionId);
    Task<List<DraftCard>> GetDraftOfferAsync(Guid sessionId, int count);
}