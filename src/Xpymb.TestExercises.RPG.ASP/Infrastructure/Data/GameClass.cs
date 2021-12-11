using MongoDB.Bson.Serialization.Attributes;
using Xpymb.TestExercises.RPG.ASP.Infrastructure.Utils;
using Xpymb.TestExercises.RPG.ASP.Models;

namespace Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

[BsonDiscriminator(RootClass = true)]
[BsonKnownTypes(typeof(WarriorGameClass), typeof(RangerGameClass), typeof(MageGameClass))]
public abstract class GameClass
{
    public abstract GameClassType ClassType { get; }
    public abstract DamageType DamageType { get; }
    public abstract int MaxAttackRadius { get; }
    public int Damage { get; } = Random.Shared.Next(5, 20);

    public abstract AttackData CalculateAttackData(Unit sourceUnit, Unit targetUnit);

    public bool HasAttack(UnitModel sourceUnit, UnitModel targetUnit)
    {
        return MathUtils.Distance(sourceUnit.X, sourceUnit.Y, targetUnit.X, targetUnit.Y) <= MaxAttackRadius;
    }
    
    public static GameClass GetGameClassByEnum(GameClassType gameClassType)
    {
        return gameClassType switch
        {
            GameClassType.Warrior => new WarriorGameClass(),
            GameClassType.Ranger => new RangerGameClass(),
            GameClassType.Mage => new MageGameClass(),
            _ => throw new ArgumentOutOfRangeException(nameof(gameClassType), gameClassType, null)
        };
    }
}