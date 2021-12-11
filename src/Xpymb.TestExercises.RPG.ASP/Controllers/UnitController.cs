using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Xpymb.TestExercises.RPG.ASP.Infrastructure;
using Xpymb.TestExercises.RPG.ASP.Models;

namespace Xpymb.TestExercises.RPG.ASP.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UnitController : ControllerBase
{
    private readonly IUnitService _unitService;
    private readonly IEngineService _engineService;

    public UnitController(
        IUnitService unitService,
        IEngineService engineService)
    {
        _unitService = unitService;
        _engineService = engineService;
    }

    [HttpGet("get")]
    public async Task<IActionResult> Get([Required] Guid id)
    {
        var result = await _unitService.GetAsync(e => e.Id == id);

        return Ok(result);
    }
    
    [HttpGet("list")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _unitService.GetManyAsync(e => true);

        return Ok(result);
    }

    [HttpPut("create")]
    public async Task<IActionResult> Create([FromBody] CreateUnitModel model)
    {
        var result = await _unitService.CreateAsync(model);
        
        return Ok(result);
    }

    [HttpPost("edit")]
    public async Task<IActionResult> Update([FromBody] UpdateUnitModel model)
    {
        var result = await _unitService.UpdateAsync(model);

        return Ok(result);
    }

    [HttpPost("attack")]
    public async Task<IActionResult> Attack([FromBody] AttackModel model)
    {
        if (model.SourceUnitId.Equals(model.TargetUnitId))
        {
            ModelState.AddModelError("TargetUnitId", "TargetUnitId cannot be equal SourceUnitId");
            return ValidationProblem();
        }
        
        var result = await _engineService.AttackAsync(model);

        return Ok(result);
    }

    [HttpDelete("remove")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _unitService.DeleteAsync(id);

        return Ok(result);
    }
}