using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CRUDRepository
{
    public class BaseRepository
    {
        private static string defaultconnectionString = "mongodb://localhost";

        protected static MongoClient client = new MongoClient(defaultconnectionString);

        public BaseRepository(string connectionString)
        {
            client = new MongoClient(connectionString);
        }

    }
}
