
using Contracts;
using Domain;

namespace Infrastructure;
public class DraftRepository : IDraftRespository
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

    public IEnumerable<Session> GetAll()
    {
        return _inMemoryDatabase;
    }

    public bool Contains(Session draft)
    {
        return _inMemoryDatabase.Contains(draft);
    }
}
