using Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

namespace Xpymb.TestExercises.RPG.ASP.Models;

public class UnitModel
{
    public Guid Id { get; set; }
    
    public int Hp { get; set; }
    public int MaxHp { get; set; }
    
    public int Mana { get; set; }
    public int MaxMana { get; set; }
    
    public int Armor { get; set; }
    public int MagicResist { get; set; }
    
    public int X { get; set; }
    public int Y { get; set; }
    
    public GameClass GameClass { get; set; }
}