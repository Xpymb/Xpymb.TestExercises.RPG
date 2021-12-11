namespace Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

public class MageGameClass : GameClass
{
    public override GameClassType ClassType { get; } = GameClassType.Mage;
    public override DamageType DamageType { get; } = DamageType.Magical;
    public override int MaxAttackRadius { get; } = 150;

    public override AttackData CalculateAttackData(Unit sourceUnit, Unit targetUnit)
    {
        var hasManaEnough = sourceUnit.Mana / 2 > 1;
        
        sourceUnit.Mana /= hasManaEnough ? 2 : 1;

        int damage = hasManaEnough ? Damage * 2 : Damage / 2 - targetUnit.MagicResist;

        targetUnit.Hp -= damage < 0 ? 0 : damage;
        
        return new AttackData { UpdatedSourceUnit = sourceUnit, UpdatedTargetUnit = targetUnit, Damage = damage};
    }
}