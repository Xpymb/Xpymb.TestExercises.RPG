using AutoMapper;
using Xpymb.TestExercises.RPG.ASP.Data;
using Xpymb.TestExercises.RPG.ASP.Data.Entities;
using Xpymb.TestExercises.RPG.ASP.Models;

namespace Xpymb.TestExercises.RPG.ASP.Infrastructure;

public class EngineService : IEngineService
{
    private readonly IUnitService _unitService;
    private readonly IDbRepository _dbRepository;
    private readonly IMapper _mapper;

    public EngineService(
        IUnitService unitService,
        IDbRepository dbRepository,
        IMapper mapper)
    {
        _unitService = unitService;
        _dbRepository = dbRepository;
        _mapper = mapper;
    }
    
    public async Task<AttackViewModel> AttackAsync(AttackModel model)
    {
        var sourceUnit = await _unitService.GetAsync(e => e.Id == model.SourceUnitId);
        var targetUnit = await _unitService.GetAsync(e => e.Id == model.TargetUnitId);

        if (!sourceUnit.GameClass.HasAttack(sourceUnit, targetUnit))
        {
            return new AttackViewModel 
            { 
                    SourceUnit = sourceUnit, 
                    TargetUnit = targetUnit, 
                    Damage = 0, 
                    Description = $"Target unit with id = { targetUnit.Id } out of range",
                    Result = AttackResult.OutOfRange,
            };
        }

        var attackData = sourceUnit.GameClass.CalculateAttackData(sourceUnit, targetUnit);

        var sourceUnitEntity = _mapper.Map<UnitEntity>(attackData.UpdatedSourceUnit);
        var targetUnitEntity = _mapper.Map<UnitEntity>(attackData.UpdatedTargetUnit);

        sourceUnitEntity = await _dbRepository.UpdateAsync(sourceUnitEntity);
        targetUnitEntity = await _dbRepository.UpdateAsync(targetUnitEntity);

        var resultSourceUnitModel = _mapper.Map<UnitModel>(sourceUnitEntity);
        var resultTargetUnitModel = _mapper.Map<UnitModel>(targetUnitEntity);
        
        return new AttackViewModel
        {
            SourceUnit = resultSourceUnitModel, 
            TargetUnit = resultTargetUnitModel, 
            Damage = attackData.Damage,
            Result = AttackResult.Attacked,
        };
    }
}