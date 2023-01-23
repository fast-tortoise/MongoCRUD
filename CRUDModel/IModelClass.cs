using MongoDB.Bson;

namespace CRUDModel
{
    public interface IModelClass
    {
        int Id { get; set; }
        string Name { get; set; }
        List<int> subjectID { get; set; }

        BsonDocument ClassBson(IModelClass modelClass);
        IModelClass CreateClass(int id, string name, List<int> subjectID);
    }
}