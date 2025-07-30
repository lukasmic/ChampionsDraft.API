using Domain;
using Domain.Enums;

namespace Application.Interfaces;

public interface IDraftService
{
    Task<Draft> CreateDraftAsync(string hero, IEnumerable<Aspect> aspects, IEnumerable<string> rules);
    Task<Draft?> GetDraftAsync(Guid draftId);
    Task<List<DraftCard>> GetOfferAsync(Guid draftId, int count);
}