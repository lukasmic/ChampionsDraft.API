using Domain;

namespace Contracts;

public interface IDraftRepository
{
    void Add(Draft draft);
    bool Contains(Draft draft);
    Task<IEnumerable<Draft>> GetAll();
    bool Remove(Draft draft);
}