using System.ComponentModel.DataAnnotations;
using Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

namespace Xpymb.TestExercises.RPG.ASP.Models;

public class UpdateUnitModel
{
    [Required] public Guid Id { get; set; }
    [Required] public GameClassType ClassType { get; set; }
}