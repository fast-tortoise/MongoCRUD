using MongoDB.Driver;
using MongoDB.Bson;
using Exceptions;

namespace CRUDRepository
{
    public class UpdateRepository : BaseRepository, IUpdate
    {

        public UpdateRepository(string connectionString) : base(connectionString) { }

        public bool UpdateCollectionName(string updateInDatabase, string OldName, string NewName)
        {
            try
            { 
                var database = client.GetDatabase(updateInDatabase);

                database.RenameCollection(OldName, NewName);
                return true;


            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"Update collection failed");
            }
        }

        public void UpdateData(string updateInDatabase, string updateInCollection, string key, int value, string updateKey, int updateValue)
        {
            try
            {
                var database = client.GetDatabase(updateInDatabase);

                var collection = database.GetCollection<BsonDocument>(updateInCollection);

                var filter = Builders<BsonDocument>.Filter.Eq(key, value);

                var update = Builders<BsonDocument>.Update.Set(updateKey, updateValue);

                collection.UpdateOne(filter, update);
            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"Read all databases failed");
            }

        }

        public void updateIDList(string updateInDatabase, string updateInCollection, string key, int value, string updateKey, List<int> updateValue)
        {
            try
            {
                var database = client.GetDatabase(updateInDatabase);

                var collection = database.GetCollection<BsonDocument>(updateInCollection);

                var filter = Builders<BsonDocument>.Filter.Eq(key, value);

                var update = Builders<BsonDocument>.Update.Set(updateKey, updateValue);
            }
            catch (Exception e)
            {
                throw new MaerskCommandFailedException($"Read all databases failed");
            }
        }
    }
}
