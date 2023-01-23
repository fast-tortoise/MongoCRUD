using MongoDB.Driver;
using MongoDB.Bson;
using Exceptions;

namespace CRUDRepository
{
    public class DeleteRepository : BaseRepository, IDelete
    {
        public DeleteRepository(string connectionString) : base(connectionString) { }
        public void DropDatabase(string dbName)
        {
            // not implemented
            try
            {
                //string dbName = "TestSchool";
                client.DropDatabase(dbName);
            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"delete database failed");
            }
}

        public bool DropCollection(string dbName, string collection)
        {
            try
            {
                var database = client.GetDatabase(dbName);
                
                database.DropCollection(collection);
                
                return true;
                
            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"collection {collection} drop failed");
            }
        }

        public void DeleteDocument(string deleteFromDatabase, string deleteFromCollection)
        {
            try
            {
                var database = client.GetDatabase(deleteFromDatabase);

            var collection = database.GetCollection<BsonDocument>(deleteFromCollection);

            var deleteFilter = Builders<BsonDocument>.Filter.Eq("classId", 1);

            var deleteResult = collection.DeleteOne(deleteFilter);
            

            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"deleting document from {deleteFromCollection} collection failed");
            }

        }
    }

}
