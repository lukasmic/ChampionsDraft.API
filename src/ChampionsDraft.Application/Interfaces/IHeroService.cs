using ChampionsDraft.Domain;

namespace ChampionsDraft.Application.Interfaces;

public interface IHeroService
{
    Task<IEnumerable<Hero>> GetAllHeroesAsync();
    Task<IEnumerable<Hero>> GetRandomHeroesAsync(int choiceCount);
}