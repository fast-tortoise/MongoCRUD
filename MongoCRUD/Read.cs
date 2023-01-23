using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoCRUD
{
    internal class Read
    {
        private readonly MongoClient _client;
        public Read(MongoClient client) 
        {
            _client = client;
        }

        public List<string> ReadAllDatabase()
        {
            var databaseNames = _client.ListDatabaseNames().ToList();

            return databaseNames;
            
        }

        public List<string> ReadCollection(string readFromDatabase)
        {
            var database = _client.GetDatabase(readFromDatabase);

            var collections = database.ListCollectionNames().ToList();

            return collections;
            
        }

        public List<BsonDocument> ReadDocuments(string readFromDatabase, string readFromCollection)
        {
            var database = _client.GetDatabase(readFromDatabase);

            var collection = database.GetCollection<BsonDocument>(readFromCollection);
            
            var documents = collection.Find(new BsonDocument()).ToList();

            return documents;
        }

        public BsonDocument ReadDocumentByID(string readFromDatabase, string readFromCollection, string key, int value)
        {
            var database = _client.GetDatabase(readFromDatabase);

            var collection = database.GetCollection<BsonDocument>(readFromCollection);

            var filter = Builders<BsonDocument>.Filter.Eq(key, value);
            var document = collection.Find(filter).FirstOrDefault();

            return document;

        }
    }
}
