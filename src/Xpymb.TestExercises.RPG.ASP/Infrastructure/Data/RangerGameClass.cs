using Xpymb.TestExercises.RPG.ASP.Infrastructure.Utils;

namespace Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

public class RangerGameClass : GameClass
{
    public override GameClassType ClassType { get; } = GameClassType.Ranger;
    public override DamageType DamageType { get; } = DamageType.Physical;
    public override int MaxAttackRadius { get; } = 350;

    public override AttackData CalculateAttackData(Unit sourceUnit, Unit targetUnit)
    {
        int damage = (int) Math.Floor(Damage +
                                      MathUtils.Distance(sourceUnit.X, sourceUnit.Y, targetUnit.X, targetUnit.Y)
                                      / MaxAttackRadius * Damage) - targetUnit.Armor;

        targetUnit.Hp -= damage < 0 ? 0 : damage;
        
        return new AttackData { UpdatedSourceUnit = sourceUnit, UpdatedTargetUnit = targetUnit, Damage = damage};
    }
}