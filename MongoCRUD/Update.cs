using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoCRUD
{
    internal class Update
    {
        private readonly MongoClient _client;
        public Update(MongoClient client)
        {
            _client = client;


        }

        public void UpdateCollectionName(string updateInDatabase, string OldName, string NewName)
        {
            var database = _client.GetDatabase(updateInDatabase);

            string updateInCollection = "School1";

            database.RenameCollection(OldName, NewName);
        }

        public void UpdateData(string updateInDatabase, string updateInCollection, string key, int value, string updateKey, int updateValue)
        {
            var database = _client.GetDatabase(updateInDatabase);

            var collection = database.GetCollection<BsonDocument>(updateInCollection);

            var filter = Builders<BsonDocument>.Filter.Eq(key, value);


            var update = Builders<BsonDocument>.Update.Set(updateKey, updateValue);

            collection.UpdateOne(filter, update);


        }

        public void updateIDList(string updateInDatabase, string updateInCollection, string key, int value, string updateKey, List<int> updateValue)
        {
            var database = _client.GetDatabase(updateInDatabase);

            var collection = database.GetCollection<BsonDocument>(updateInCollection);

            var filter = Builders<BsonDocument>.Filter.Eq(key, value);

            var update = Builders<BsonDocument>.Update.Set(updateKey, updateValue);
        }

        //trail code
        public void AddKeyValuePairToDoc(string updateInDatabase, string updateInCollection, string key, int value, string updateKey, List<int> updateValue)
        {
            var database = _client.GetDatabase(updateInDatabase);

            var collection = database.GetCollection<BsonDocument>(updateInCollection);

            var filter = Builders<BsonDocument>.Filter.Eq(key, value);

            var docoriginal = collection.Find<BsonDocument>(filter);

            var document = new BsonDocument
            {
                { "student_id", 10000 },
                { "scores", new BsonArray
                    {
                    new BsonDocument{ {"type", "exam"}, {"score", 88.12334193287023 } },
                    new BsonDocument{ {"type", "quiz"}, {"score", 74.92381029342834 } },
                    new BsonDocument{ {"type", "homework"}, {"score", 89.97929384290324 } },
                    new BsonDocument{ {"type", "homework"}, {"score", 82.12931030513218 } }
                    }
                },
                { "class_id", 480}
            };

            var json1 = docoriginal.ToJson(new MongoDB.Bson.IO.JsonWriterSettings());
            var json2 = document.ToJson(new MongoDB.Bson.IO.JsonWriterSettings());

            var jsonFinal = json1 + json2;


        }
    }
}
