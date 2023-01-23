using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoCRUD
{
    internal class Create
    {
        private readonly MongoClient _client;
        public Create(MongoClient client)
        {
            _client = client;
        }

        public void CreateOrOpenDatabase(string createDatabase, string collection)
        {

            var database = _client.GetDatabase(createDatabase);
            CreateCollection(database, collection);

        }

        public void CreateCollection(IMongoDatabase database, string newCollection)
        {
             database.CreateCollection(newCollection);

        }


        
        public void CreateDocument(string writeToDatabase, string writeToCollection, BsonDocument document)
        {
            var database = _client.GetDatabase(writeToDatabase);

            var collection = database.GetCollection<BsonDocument>(writeToCollection);

            collection.InsertOne(document);
        }

            

    }
}
