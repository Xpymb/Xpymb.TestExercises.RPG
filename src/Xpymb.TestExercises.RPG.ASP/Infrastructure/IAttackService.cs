using Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;
using Xpymb.TestExercises.RPG.ASP.Models;

namespace Xpymb.TestExercises.RPG.ASP.Infrastructure;

public interface IAttackService
{
    Task<AttackViewModel> AttackAsync(AttackModel model);
}