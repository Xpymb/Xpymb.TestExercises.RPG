using Xpymb.TestExercises.RPG.ASP.Models;

namespace Xpymb.TestExercises.RPG.ASP.Infrastructure;

public interface IEngineService
{
    Task<AttackViewModel> AttackAsync(AttackModel model);
}