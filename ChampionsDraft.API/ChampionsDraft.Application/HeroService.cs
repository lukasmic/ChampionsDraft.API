using Application.Interfaces;
using Contracts;
using Domain;

namespace Application;

public class HeroService(IMarvelCdbClient mcdbClient) : IHeroService
{
    private readonly IMarvelCdbClient _mcdbClient = mcdbClient;

    public async Task<IEnumerable<Hero>> GetAllHeroesAsync()
    {
        return await GetHeroesFromApiAsync();
    }

    public async Task<IEnumerable<Hero>> GetRandomHeroesAsync(int choiceCount)
    {
        var heroes = await GetHeroesFromApiAsync();

        var random = new Random();
        return heroes.OrderBy(_ => random.Next()).Take(choiceCount);
    }

    private async Task<IEnumerable<Hero>> GetHeroesFromApiAsync()
    {
        var result = await _mcdbClient.GetCardsAsync();
        return result
            .Where(card => card.TypeName == "Hero" && card.Code.EndsWith('a'))
            .Select(hero => new Hero()
            {
                Code = hero.Code,
                Name = hero.Name,
                PackCode = hero.PackCode,
                ImageUrl = hero.Imagesrc
            })
            .Distinct(comparer: new HeroNameComparer())

            // Special case for SP//dr, which has "Suit" in its name
            .Select(hero => hero.Code == "31001a"
                    ? new Hero()
                    {
                        Code = hero.Code,
                        Name = "SP//dr",
                        PackCode = hero.PackCode,
                        ImageUrl = hero.ImageUrl
                    } : hero);
    }
}

internal class HeroNameComparer : IEqualityComparer<Hero>
{
    public bool Equals(Hero? x, Hero? y)
    {
        if (x is null || y is null) return false;
        return string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
    }

    public int GetHashCode(Hero obj)
    {
        return obj.Name?.GetHashCode(StringComparison.OrdinalIgnoreCase) ?? 0;
    }
}
