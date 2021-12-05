using Xpymb.TestExercises.RPG.ASP.Infrastructure.Helpers;
using Xpymb.TestExercises.RPG.ASP.Models;

namespace Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

public class RangeGameClass : GameClass
{
    public override DamageType DamageType { get; } = DamageType.Physical;
    public override int MaxAttackRadius { get; } = 350;

    public override int CalculateDamage(UnitModel sourceUnit, UnitModel targetUnit)
    {
        var damage = (int) Math.Floor(Damage +
                                      MathHelper.Distance(sourceUnit.X, sourceUnit.Y, targetUnit.X, targetUnit.Y)
                                      / MaxAttackRadius * Damage) - targetUnit.Armor;
        
        return damage > 0 ? damage : 0;
    }

    public override bool HasAttack(UnitModel targetUnit)
    {
        throw new NotImplementedException();
    }
}