namespace Xpymb.TestExercises.RPG.ASP.Models;

public class AttackViewModel
{
    public UnitModel SourceUnit { get; set; }
    public UnitModel TargetUnit { get; set; }
    public double Damage { get; set; }
    public string Description { get; set; }
    public AttackResult Result { get; set; }
}