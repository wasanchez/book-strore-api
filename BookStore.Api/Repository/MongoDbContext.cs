using BookStore.Api.Models;
using BookStore.Api.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.Api;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _mongoDatabase;
    private readonly IOptions<BookStoreDatabaseSettings> _databaseSettings;
    public MongoDbContext(IOptions<BookStoreDatabaseSettings> databaseSettings)
    {
        _databaseSettings = databaseSettings;
        
        var mongoClient = new MongoClient(_databaseSettings.Value.ConnectionString);
        _mongoDatabase = mongoClient.GetDatabase(_databaseSettings.Value.DatabaseName);
    }

    public IMongoCollection<T> GetMongoCollection<T>(string? collectionName = null) where T : class
    {
        collectionName = collectionName ?? GetCollectionName<T>();
        return _mongoDatabase.GetCollection<T>(collectionName);
    }

    public IMongoDatabase GetMongoDatabase()
    {
       return _mongoDatabase;
    }

    private string GetCollectionName<T>() {
        var documentName =  typeof(T).Name;
        var setting =  _databaseSettings.Value.Collections.Where(c => c.EntityName == documentName).FirstOrDefault();
        if (setting == null) throw new MongoClientException($"The collection for entity {documentName} is not configured.");
        return setting.DocumentName;
    }
}
