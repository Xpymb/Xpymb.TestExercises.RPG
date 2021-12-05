using Xpymb.TestExercises.RPG.ASP.Models;

namespace Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

public class MageGameClass : GameClass
{
    public override DamageType DamageType { get; } = DamageType.Magical;
    public override int MaxAttackRadius { get; } = 150;

    public override int CalculateDamage(UnitModel sourceUnit, UnitModel targetUnit)
    {
        var hasManaEnough = sourceUnit.Mana / 2 > 1;
        
        sourceUnit.Mana /= hasManaEnough ? 2 : 1;

        var damage = hasManaEnough ? Damage * 2 : Damage / 2 - targetUnit.MagicResist;
        
        return damage > 0 ? damage : 0;
    }

    public override bool HasAttack(UnitModel targetUnit)
    {
        throw new NotImplementedException();
    }
}