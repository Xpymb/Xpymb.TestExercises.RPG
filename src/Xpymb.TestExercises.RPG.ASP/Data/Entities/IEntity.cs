using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Xpymb.TestExercises.RPG.ASP.Data.Entities;

public interface IEntity
{
    [BsonRepresentation(BsonType.ObjectId)]
    Guid Id { get; set; }
    
    bool IsActive { get; set; }
    
    DateTime DateCreated { get; set; }
    DateTime? DateUpdated { get; set; }
}