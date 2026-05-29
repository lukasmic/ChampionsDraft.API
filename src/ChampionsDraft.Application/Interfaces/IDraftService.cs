using ChampionsDraft.Domain;
using ChampionsDraft.Domain.Enums;
using ChampionsDraft.Shared.Models;

namespace ChampionsDraft.Application.Interfaces;

public interface IDraftService
{
    Task<Result<Draft>> CreateDraftAsync(string hero, IEnumerable<Aspect> aspects, IEnumerable<string> rules);
    Task<List<Draft>> GetAllDraftsAsync();
    Task<Draft?> GetDraftAsync(Guid draftId);
    Task<List<DraftCard>> GetOfferAsync(Guid draftId, int count);
}