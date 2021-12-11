using System.Linq.Expressions;
using AutoMapper;
using Xpymb.TestExercises.RPG.ASP.Data;
using Xpymb.TestExercises.RPG.ASP.Data.Entities;
using Xpymb.TestExercises.RPG.ASP.Models;
using Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;

namespace Xpymb.TestExercises.RPG.ASP.Infrastructure;

public class UnitService : IUnitService
{
    private readonly IDbRepository _dbRepository;
    private readonly IMapper _mapper;

    public UnitService(
        IDbRepository dbRepository,
        IMapper mapper)
    {
        _dbRepository = dbRepository;
        _mapper = mapper;
    }
    
    public async Task<UnitModel> GetAsync(Expression<Func<UnitEntity, bool>> selector)
    {
        var entities = await _dbRepository.GetAsync(selector);
        var entity = entities.FirstOrDefault();
        
        var result = _mapper.Map<UnitModel>(entity);
        
        return result;
    }

    public async Task<IEnumerable<UnitModel>> GetManyAsync(Expression<Func<UnitEntity, bool>> selector)
    {
        var entities = await _dbRepository.GetAsync(selector);
        
        var listModels = entities.Select(entity => _mapper.Map<UnitModel>(entity)).ToList();

        return listModels;
    }

    public async Task<UnitModel> CreateAsync(CreateUnitModel model)
    {
        // create unit with classtype to get predefined fields and then map with ready fields
        var unit = new Unit
        {
            GameClass = GameClass.GetGameClassByEnum(model.ClassType),
        };
        var entity = _mapper.Map<UnitEntity>(unit);

        var resultEntity = await _dbRepository.AddAsync(entity);
        var resultModel = _mapper.Map<UnitModel>(resultEntity);
        
        return resultModel;
    }

    public async Task<UnitModel> UpdateAsync(UpdateUnitModel model)
    {
        var entity = _mapper.Map<UnitEntity>(await GetAsync(e => e.Id == model.Id));

        entity.GameClass = GameClass.GetGameClassByEnum(model.ClassType);
        
        var resultEntity = await _dbRepository.UpdateAsync(entity);
        var resultModel = _mapper.Map<UnitModel>(resultEntity);

        return resultModel;
    }

    public async Task<UnitModel> DeleteAsync(Guid id)
    {
        var resultEntity = await _dbRepository.DeleteAsync<UnitEntity>(id);
        var resultModel = _mapper.Map<UnitModel>(resultEntity);

        return resultModel;
    }
}