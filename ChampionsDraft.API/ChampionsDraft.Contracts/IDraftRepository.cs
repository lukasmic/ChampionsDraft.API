using Domain;

namespace Contracts;

public interface IDraftRepository
{
    void Add(Session draft);
    bool Contains(Session draft);
    Task<IEnumerable<Session>> GetAll();
    bool Remove(Session draft);
}