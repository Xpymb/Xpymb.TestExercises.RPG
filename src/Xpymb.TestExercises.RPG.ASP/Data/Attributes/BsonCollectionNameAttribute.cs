namespace Xpymb.TestExercises.RPG.ASP.Data.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class BsonCollectionNameAttribute : Attribute
{
    public string CollectionName { get; }

    public BsonCollectionNameAttribute(string collectionName)
    {
        CollectionName = collectionName;
    }
}