using System.Linq.Expressions;
using Xpymb.TestExercises.RPG.ASP.Data.Entities;
using Xpymb.TestExercises.RPG.ASP.Models;

namespace Xpymb.TestExercises.RPG.ASP.Infrastructure;

/// <summary>
/// CRUD operations above Unit
/// </summary>
public interface IUnitService
{
    Task<UnitModel> GetAsync(Expression<Func<UnitEntity, bool>> selector);
    Task<IEnumerable<UnitModel>> GetManyAsync(Expression<Func<UnitEntity, bool>> selector);
    Task<UnitModel> CreateAsync(CreateUnitModel model);
    Task<UnitModel> UpdateAsync(UpdateUnitModel model);
    Task<UnitModel> DeleteAsync(Guid id);
}