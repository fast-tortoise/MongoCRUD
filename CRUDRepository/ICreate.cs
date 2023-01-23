using MongoDB.Bson;
using MongoDB.Driver;

namespace CRUDRepository
{
    public interface ICreate
    {
        IMongoCollection<BsonDocument> CreateCollection(IMongoDatabase database, string newCollection);
        IMongoCollection<BsonDocument> CreateCollection(string database, string newCollection);
        bool CreateDocument(IMongoCollection<BsonDocument> collection, BsonDocument document);
        bool CreateDocument(string writeToDatabase, string writeToCollection, BsonDocument document);
        IMongoCollection<BsonDocument> CreateOrOpenDatabase(string createDatabase, string collection);
    }
}