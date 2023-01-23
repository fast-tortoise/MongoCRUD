using MongoDB.Driver;
using MongoDB.Bson;
using Exceptions;
namespace CRUDRepository
{
    public class CreateRepository : BaseRepository, ICreate
    {
        public CreateRepository(string connectionString) : base(connectionString) { }
        public IMongoCollection<BsonDocument> CreateOrOpenDatabase(string createDatabase, string collection)
        {
            if (createDatabase == null)
                throw new ArgumentNullException(nameof(createDatabase));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            try
            {
                var database = client.GetDatabase(createDatabase);
                var coll = CreateCollection(database, collection);
                return coll;
            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"Open or Create {createDatabase} database failed");
            }
        }
        public IMongoCollection<BsonDocument> CreateCollection(string database, string newCollection)
        {
            if(database == null)    
                throw new ArgumentException(nameof(database));
            if(newCollection == null) throw new ArgumentNullException(nameof(newCollection));   

            try
            {
                var collection = CreateOrOpenDatabase(database, newCollection);
                return collection;
            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"Open or Create {newCollection} collection failed");
            }
        }

        public IMongoCollection<BsonDocument> CreateCollection(IMongoDatabase database, string newCollection)
        {
            if (database == null)
                throw new ArgumentNullException("database void");

            if(newCollection == null) 
                throw new ArgumentNullException(nameof(newCollection));   

            try
            {
                var collection = database.GetCollection<BsonDocument>(newCollection);
                return collection;
            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"Open or Create {newCollection} collection failed");
            }
        }
        public bool CreateDocument(string writeToDatabase, string writeToCollection, BsonDocument document)
        {
            if(writeToDatabase == null)
                throw new ArgumentNullException(nameof(writeToCollection));

            if (writeToCollection == null) throw new ArgumentNullException(nameof(writeToCollection));

            if(document == null) throw new ArgumentNullException(nameof(document));
            try
            {
                var database = client.GetDatabase(writeToDatabase);
                var collection = database.GetCollection<BsonDocument>(writeToCollection);

                collection.InsertOne(document);
                return true;
            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"Document creation in {writeToCollection} collection failed");
            }
        }

        public bool CreateDocument(IMongoCollection<BsonDocument> collection, BsonDocument document)
        {
            if(collection==null)
                throw new ArgumentNullException(nameof(collection));

            if(document==null) throw new ArgumentNullException(nameof(document));
            try
            {
                collection.InsertOne(document);
                return true;
            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"Document insertion in collection failed");
            }
        }
    }
}
