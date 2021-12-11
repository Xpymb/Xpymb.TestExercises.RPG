using Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

namespace Xpymb.TestExercises.RPG.ASP.Data.Entities;

public class GameClassEntity
{
    public GameClassType GameClassType { get; set; }
    public DamageType DamageType { get; set; }
    public int Damage { get; set; }
}