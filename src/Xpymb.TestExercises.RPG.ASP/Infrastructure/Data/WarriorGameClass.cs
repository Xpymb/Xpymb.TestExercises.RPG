namespace Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

public class WarriorGameClass : GameClass
{
    public override GameClassType ClassType { get; } = GameClassType.Warrior;
    public override DamageType DamageType { get; } = DamageType.Physical;
    public override int MaxAttackRadius { get; } = 10;

    public override AttackData CalculateAttackData(Unit sourceUnit, Unit targetUnit)
    {
        int damage = Damage + (sourceUnit.MaxHp - sourceUnit.Hp) / sourceUnit.MaxHp * Damage - targetUnit.Armor;

        targetUnit.Hp -= damage < 0 ? 0 : damage;
        
        return new AttackData { UpdatedSourceUnit = sourceUnit, UpdatedTargetUnit = targetUnit, Damage = damage};
    }
}