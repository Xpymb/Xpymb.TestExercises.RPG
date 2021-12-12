using System.ComponentModel.DataAnnotations;

namespace Xpymb.TestExercises.RPG.ASP.Models;

public class AttackModel
{
    [Required] public Guid SourceUnitId { get; set; }
    [Required] public Guid TargetUnitId { get; set; }
}