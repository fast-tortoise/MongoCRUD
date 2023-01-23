using MongoDB.Bson;

namespace CRUDRepository
{
    public interface IRead
    {
        List<string> ReadAllDatabase();
        List<string> ReadCollection(string readFromDatabase);
        BsonDocument ReadDocumentByID(string readFromDatabase, string readFromCollection, string key, int value);
        List<BsonDocument> ReadDocuments(string readFromDatabase, string readFromCollection);
    }
}