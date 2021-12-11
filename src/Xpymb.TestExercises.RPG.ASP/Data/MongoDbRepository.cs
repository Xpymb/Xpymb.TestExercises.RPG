using System.ComponentModel;
using System.Linq.Expressions;
using MongoDB.Driver;
using Xpymb.TestExercises.RPG.ASP.Data.Entities;

namespace Xpymb.TestExercises.RPG.ASP.Data;

public class MongoDbRepository : IDbRepository
{
    private readonly MongoDbContext _mongoDbContext;

    public MongoDbRepository(
        MongoDbContext mongoDbContext)
    {
        _mongoDbContext = mongoDbContext;
    }

    public async Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> selector) where T : class, IEntity
    {
        var collection = _mongoDbContext.GetCollection<T>();

        var result = await Task.Run(() => collection.Find(selector).ToEnumerable());
        
        return result;
    }

    public async Task<T> AddAsync<T>(T entity) where T : class, IEntity
    {
        var collection = _mongoDbContext.GetCollection<T>();

        await collection.InsertOneAsync(entity);

        var result = await collection.Find(e => e.Id == entity.Id).FirstOrDefaultAsync();
        return result;
    }

    public async Task<T> UpdateAsync<T>(T entity) where T : class, IEntity
    {
        var collection = _mongoDbContext.GetCollection<T>();

        var result = await collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);

        if (!result.IsAcknowledged)
        {
            throw new WarningException($"Entity update with id = { entity.Id } not completed");
        }

        var resultEntity = await collection.Find(e => e.Id == entity.Id).FirstOrDefaultAsync();
        return resultEntity;
    }

    public async Task<T> DeleteAsync<T>(Guid id) where T : class, IEntity
    {
        var collection = _mongoDbContext.GetCollection<T>();

        var entity = await collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        
        if (entity is null)
        {
            throw new WarningException($"Entity with id = { id } not found");
        }
        
        var result = await collection.DeleteOneAsync(e => e.Id == id);
        
        if (!result.IsAcknowledged)
        {
            throw new WarningException($"Entity delete with id = { id } not completed");
        }

        return entity;
    }
}