using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoCRUD
{
    internal class Delete
    {
        private readonly MongoClient _client;
        public Delete(MongoClient client)
        {
            _client = client;
        }

        public void DropDatabase()
        {
            string dbName = "TestSchool";
            _client.DropDatabase(dbName);

        }

        public void DropCollection(string dbName, string collection)
        {
            var database = _client.GetDatabase(dbName);
            database.DropCollection(collection);
        }

        public void DeleteDocument(string deleteFromDatabase, string deleteFromCollection )
        {
            var database = _client.GetDatabase(deleteFromDatabase);

            var collection = database.GetCollection<BsonDocument>(deleteFromCollection);

            var deleteFilter = Builders<BsonDocument>.Filter.Eq("classId", 1);

            collection.DeleteOne(deleteFilter);

        }
    }

}



//for multiple delete
//var deleteLowExamFilter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>
//    ("scores",  new BsonDocument 
//    { { "type", "exam" }, 
//        {"score", new BsonDocument { 
//            { "$lt", 60 }
//        }
//      }
//    });

//collection.DeleteMany(deleteLowExamFilter);
