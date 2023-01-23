using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDRepository;
using MongoDB.Driver;
using MongoDB.Bson;
using CRUDModel;
using Exceptions;

namespace ConsoleTest
{
    public class RepositoryTests
    {
        private static string defaultconnectionString = "mongodb://localhost";

        ICreate createRepository = new CreateRepository(defaultconnectionString);
        IDelete deleteRepository = new DeleteRepository(defaultconnectionString);
        IRead readRepository = new ReadRepository(defaultconnectionString);
        IUpdate updateRepository = new UpdateRepository(defaultconnectionString);


        [Fact]
        public void TestCreateDocumentInCollection()
        {
            var coll = createRepository.CreateCollection("testClass", "testCollection");

            BsonDocument bson = new BsonDocument{
                { "student_id", 10000 } };

            createRepository.CreateDocument(coll, bson);

            var listAllDatabase = readRepository.ReadAllDatabase();

            Assert.NotNull(listAllDatabase);

            Assert.Contains("testClass", listAllDatabase);

            var listColl = readRepository.ReadCollection("testClass");

            Assert.Contains("testCollection", listColl);

            deleteRepository.DropDatabase("testClass");

            var listAllDatabase2 = readRepository.ReadAllDatabase();

            Assert.NotNull(listAllDatabase2);

            Assert.DoesNotContain("testClass", listAllDatabase2);

        }

        [Fact]
        public void TestUpdateCollection()
        {

            var coll = createRepository.CreateCollection("testClass", "testCollection");

            BsonDocument bson = new BsonDocument{
                { "student_id", 10000 } };

            createRepository.CreateDocument(coll, bson);

            var listAllDatabase = readRepository.ReadAllDatabase();

            Assert.NotNull(listAllDatabase);

            Assert.Contains("testClass", listAllDatabase);

            var listColl = readRepository.ReadCollection("testClass");

            Assert.Contains("testCollection", listColl);

            updateRepository.UpdateCollectionName("testClass", "testCollection", "newTestColl");

            var listColl2 = readRepository.ReadCollection("testClass");

            Assert.Contains("newTestColl", listColl2);

            Assert.DoesNotContain("testCollection", listColl2);

            deleteRepository.DropDatabase("testClass");

            var listAllDatabase2 = readRepository.ReadAllDatabase();

            Assert.NotNull(listAllDatabase2);

            Assert.DoesNotContain("testClass", listAllDatabase2);

        }

        [Fact]

        public void TestUpdateData()
        {

            var coll = createRepository.CreateCollection("testClass", "testCollection");

            BsonDocument bson = new BsonDocument{
                { "student_id", 10000 } };

            createRepository.CreateDocument(coll, bson);

            var listAllDatabase = readRepository.ReadAllDatabase();

            Assert.NotNull(listAllDatabase);

            Assert.Contains("testClass", listAllDatabase);

            var listColl = readRepository.ReadCollection("testClass");

            Assert.Contains("testCollection", listColl);

            updateRepository.UpdateData("testClass", "testCollection", "student_id", 10000, "student_id", 50000);

            deleteRepository.DropDatabase("testClass");

            var listAllDatabase2 = readRepository.ReadAllDatabase();

            Assert.NotNull(listAllDatabase2);

            Assert.DoesNotContain("testClass", listAllDatabase2);

        }


    }
}
