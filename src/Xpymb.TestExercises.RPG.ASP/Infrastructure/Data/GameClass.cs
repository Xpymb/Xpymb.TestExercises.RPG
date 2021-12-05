using Xpymb.TestExercises.RPG.ASP.Models;

namespace Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

public abstract class GameClass
{
    public abstract DamageType DamageType { get; }
    public abstract int MaxAttackRadius { get; }
    protected int Damage = Random.Shared.Next(5, 20);
    
    public abstract int CalculateDamage(UnitModel sourceUnit, UnitModel targetUnit);
    public abstract bool HasAttack(UnitModel targetUnit);
}