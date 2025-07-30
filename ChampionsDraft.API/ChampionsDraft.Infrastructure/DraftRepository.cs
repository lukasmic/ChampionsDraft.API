
using Contracts;
using Domain;

namespace Infrastructure;

public class DraftRepository : IDraftRepository
{
    private readonly List<Draft> _inMemoryDatabase;

    public DraftRepository()
    {
        _inMemoryDatabase = new List<Draft>();
    }

    public void Add(Draft draft)
    {
        _inMemoryDatabase.Add(draft);
    }

    public bool Remove(Draft draft)
    {
        return _inMemoryDatabase.Remove(draft);
    }

    public Task<IEnumerable<Draft>> GetAll()
    {
        return Task.FromResult<IEnumerable<Draft>>(_inMemoryDatabase);
    }

    public bool Contains(Draft draft)
    {
        return _inMemoryDatabase.Contains(draft);
    }
}
