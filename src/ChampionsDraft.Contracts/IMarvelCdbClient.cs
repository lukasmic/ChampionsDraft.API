using ChampionsDraft.Contracts.Models;

namespace ChampionsDraft.Contracts;

public interface IMarvelCdbClient
{
    Task<IEnumerable<CardDTO>> GetCardsAsync();
}
