using Xpymb.TestExercises.RPG.ASP.Models;
using Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

namespace Xpymb.TestExercises.RPG.ASP.Infrastructure;

/// <summary>
/// CRUD operations above Unit
/// </summary>
public interface IUnitService
{
    Task<UnitModel> GetAsync(Guid id);
    Task<IEnumerable<UnitModel>> GetAllAsync();
    Task<UnitModel> CreateAsync(CreateUnitModel model);
    Task<UnitModel> UpdateAsync(UpdateUnitModel model);
    Task<UnitModel> DeleteAsync(Guid id);
}