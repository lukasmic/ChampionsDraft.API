using Contracts.Models;

namespace Contracts;

public interface IMarvelCdbClient
{
    Task<IEnumerable<CardDTO>> GetCards();
}
