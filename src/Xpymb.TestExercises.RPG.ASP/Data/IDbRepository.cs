using System.Linq.Expressions;
using Xpymb.TestExercises.RPG.ASP.Data.Entities;

namespace Xpymb.TestExercises.RPG.ASP.Data;

public interface IDbRepository
{
    Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> selector) where T : class, IEntity;
    Task<T> AddAsync<T>(T entity) where T : class, IEntity;
    Task<T> UpdateAsync<T>(T entity) where T : class, IEntity;
    Task<T> DeleteAsync<T>(Guid id) where T : class, IEntity;
}