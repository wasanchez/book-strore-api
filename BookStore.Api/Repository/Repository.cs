
using BookStore.Api.Models;
using MongoDB.Driver;

namespace BookStore.Api.Repository;

public class Repository<T, TId> : IRepostory<T, TId> where T : EntityBase<TId>
{
    private readonly IMongoDbContext _mongoDbContext;
    private readonly IMongoCollection<T> _collection;

    public Repository(IMongoDbContext mongoDbContext)
    {
        _mongoDbContext = mongoDbContext;
        _collection = _mongoDbContext.GetMongoCollection<T>();
    }
 
    public async Task CreateAsync(T newEntity) =>
        await _collection.InsertOneAsync(newEntity); 

    public async Task<List<T>> GetAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<T?> GetAsync(TId id) =>
        await _collection.Find(x => x.Id.Equals(id)).FirstOrDefaultAsync();

    public async Task RemoveAsync(TId id) => 
        await _collection.DeleteOneAsync(x => x.Id.Equals(id));

    public async Task UpdateAsync(TId id, T updatedEntity) =>
        await _collection.ReplaceOneAsync(x => x.Id.Equals(id), updatedEntity);
}
