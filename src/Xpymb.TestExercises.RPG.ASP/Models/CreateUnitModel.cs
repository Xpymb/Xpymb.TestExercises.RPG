using System.ComponentModel.DataAnnotations;
using Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

namespace Xpymb.TestExercises.RPG.ASP.Models;

public class CreateUnitModel
{
    [Required] public GameClassType ClassType { get; set; }
}