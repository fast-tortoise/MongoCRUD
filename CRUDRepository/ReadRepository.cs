using MongoDB.Driver;
using MongoDB.Bson;
using Exceptions;

namespace CRUDRepository
{
    public class ReadRepository : BaseRepository, IRead
    {

        public ReadRepository(string connectionString) : base(connectionString) { }
        public List<string> ReadAllDatabase()
        {
            try
            {
                var databaseNames = client.ListDatabaseNames().ToList();

                return databaseNames;
            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"Read all databases failed");
            }

        }

        public List<string> ReadCollection(string readFromDatabase)
        {
            try
            {
                var database = client.GetDatabase(readFromDatabase);

                var collections = database.ListCollectionNames().ToList();
                return collections;

            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"Read from {readFromDatabase} database failed");
            }

        }

        public List<BsonDocument> ReadDocuments(string readFromDatabase, string readFromCollection)
        {
            try
            {
                var database = client.GetDatabase(readFromDatabase);

                var collection = database.GetCollection<BsonDocument>(readFromCollection);

                var documents = collection.Find(new BsonDocument()).ToList();

            return documents;
            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"Read documents from {readFromCollection} collection failed");
            }
        }

        public BsonDocument ReadDocumentByID(string readFromDatabase, string readFromCollection, string key, int value)
        {
            try
            {
                var database = client.GetDatabase(readFromDatabase);

                var collection = database.GetCollection<BsonDocument>(readFromCollection);

                var filter = Builders<BsonDocument>.Filter.Eq(key, value);
                var document = collection.Find(filter).FirstOrDefault();

                return document;
            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"read document from {readFromCollection} collection failed");
            }

        }

        public void ReadValuFromKey(string readFromDatabase, string readFromCollection, string key, int value)
        {
            var database = client.GetDatabase(readFromDatabase);

            var collection = database.GetCollection<BsonDocument>(readFromCollection);

            var filter = Builders<BsonDocument>.Filter.Eq(key, value);
            var document = collection.Find(filter).FirstOrDefault();


        }
    }
}
