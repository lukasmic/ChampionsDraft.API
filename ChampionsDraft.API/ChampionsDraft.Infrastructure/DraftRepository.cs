
using Contracts;
using Domain;

namespace Infrastructure;

public class DraftRepository : IDraftRepository
{
    private readonly List<Session> _inMemoryDatabase;

    public DraftRepository()
    {
        _inMemoryDatabase = new List<Session>();
    }

    public void Add(Session draft)
    {
        _inMemoryDatabase.Add(draft);
    }

    public bool Remove(Session draft)
    {
        return _inMemoryDatabase.Remove(draft);
    }

    public Task<IEnumerable<Session>> GetAll()
    {
        return Task.FromResult<IEnumerable<Session>>(_inMemoryDatabase);
    }

    public bool Contains(Session draft)
    {
        return _inMemoryDatabase.Contains(draft);
    }
}
