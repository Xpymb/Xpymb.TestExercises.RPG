using MongoDB.Driver;
using Xpymb.TestExercises.RPG.ASP.Data.Attributes;
using Xpymb.TestExercises.RPG.ASP.Data.Entities;

namespace Xpymb.TestExercises.RPG.ASP.Data;

public class MongoDbContext
{
    public IMongoClient Client { get; }
    public IMongoDatabase Database { get; }

    public MongoDbContext(
        IConfiguration configuration)
    {
        var connectionString = configuration["MongoDb:ConnectionString"];
        
        Client = new MongoClient(connectionString);
        Database = Client.GetDatabase("gamedb");
    }

    public IMongoCollection<T> GetCollection<T>() where T : IEntity
    {
        return Database.GetCollection<T>(GetCollectionName<T>(typeof(T)));
    }

    private string GetCollectionName<T>(Type documentType) where T : IEntity
    {
        var bsonCollectionAttributes = ((BsonCollectionNameAttribute?) documentType.GetCustomAttributes
            (typeof(BsonCollectionNameAttribute), false).FirstOrDefault(a => a.GetType() == typeof(BsonCollectionNameAttribute)));
        
        var collectionName = bsonCollectionAttributes is null ? 
            throw new ArgumentException($"BsonEntity with name { documentType.FullName } has no attribute [BsonCollection(name)]") : 
            bsonCollectionAttributes.CollectionName;
        
        return collectionName;
    }
}