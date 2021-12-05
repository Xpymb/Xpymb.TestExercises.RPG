using Xpymb.TestExercises.RPG.ASP.Models;

namespace Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

public class MeleeGameClass : GameClass
{
    public override DamageType DamageType { get; } = DamageType.Physical;
    public override int MaxAttackRadius { get; } = 10;

    public override int CalculateDamage(UnitModel sourceUnit, UnitModel targetUnit)
    {
        var damage = Damage + (sourceUnit.MaxHp - sourceUnit.Hp) / sourceUnit.MaxHp * Damage - targetUnit.Armor;
        
        return damage > 0 ? damage : 0;
    }

    public override bool HasAttack(UnitModel targetUnit)
    {
        throw new NotImplementedException();
    }
}