namespace Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

public class Unit
{
    public Guid Id { get; set; }

    public int Hp { get; set; } = 100;
    public int MaxHp { get; set; } = 100;

    public int Mana { get; set; } = 100;
    public int MaxMana { get; set; } = 100;
    
    public int Armor { get; set; } = Random.Shared.Next(5, 10);
    public int MagicResist { get; set; } = Random.Shared.Next(5, 10);
    
    public int X { get; set; } = Random.Shared.Next(50, 100);
    public int Y { get; set; } = Random.Shared.Next(50, 100);
    
    public GameClass GameClass { get; set; }
}