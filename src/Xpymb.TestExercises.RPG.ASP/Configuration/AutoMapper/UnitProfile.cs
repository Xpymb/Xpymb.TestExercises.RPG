using AutoMapper;
using Xpymb.TestExercises.RPG.ASP.Data.Entities;
using Xpymb.TestExercises.RPG.ASP.Infrastructure.Data;
using Xpymb.TestExercises.RPG.ASP.Models;

namespace Xpymb.TestExercises.RPG.ASP.Configuration.AutoMapper;

public class UnitProfile : Profile
{
    public UnitProfile()
    {
        CreateMap<UnitModel, Unit>();
        CreateMap<Unit, UnitModel>();

        CreateMap<UnitModel, UnitEntity>();
        CreateMap<UnitEntity, UnitModel>();

        CreateMap<Unit, UnitEntity>();
        CreateMap<UnitEntity, Unit>();
        
        CreateMap<UpdateUnitModel, UnitModel>();
    }
}