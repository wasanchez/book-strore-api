using MongoDB.Driver;

namespace BookStore.Api.Repository;

public interface IMongoDbContext
{
    IMongoDatabase GetMongoDatabase();
    IMongoCollection<T> GetMongoCollection<T>(string? collectionName = null) where T : class;
}
