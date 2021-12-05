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
    private readonly IAttackService _attackService;

    public UnitController(
        IUnitService unitService,
        IAttackService attackService)
    {
        _unitService = unitService;
        _attackService = attackService;
    }

    [HttpGet("get")]
    public async Task<IActionResult> Get([Required] Guid id)
    {
        var result = await _unitService.GetAsync(id);

        return Ok(result);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _unitService.GetAllAsync();

        return result.Any() ? NotFound("Database is empty") : Ok(result);
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
        var result = await _attackService.AttackAsync(model);

        return Ok(result);
    }

    [HttpDelete("remove")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _unitService.DeleteAsync(id);

        return Ok(result);
    }
}