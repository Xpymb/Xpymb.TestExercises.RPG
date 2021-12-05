using Xpymb.TestExercises.RPG.ASP.Models;
using Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

namespace Xpymb.TestExercises.RPG.ASP.Infrastructure;

public class UnitService : IUnitService
{
    public Task<UnitModel> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UnitModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UnitModel> CreateAsync(CreateUnitModel model)
    {
        throw new NotImplementedException();
    }

    public Task<UnitModel> UpdateAsync(UpdateUnitModel model)
    {
        throw new NotImplementedException();
    }

    public Task<UnitModel> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}