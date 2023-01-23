using System.Threading.Tasks;
using CRUDBusiness;
using CRUDRepository;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using MongoDB.Driver;
using MongoDB.Bson;
using CRUDModel;
using Exceptions;

namespace ConsoleTest
{
    public class BusinessTest
    {
        private IConfiguration _config;

        private ICreate _create;
        private IDelete _delete;
        private IUpdate _update;
        private IRead _read;
        private BsonDocument _bsonDoc;
        private IMongoDatabase _database;
        private IMongoCollection<BsonDocument> _collection;
        private string _testDatabase;
        private IModelClass _modelClass;


        public BusinessTest()
        {
            _config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
               .Build();
        }

        private void setupMockPrepository()
        {
            _create = Substitute.For<ICreate>();
            _delete = Substitute.For<IDelete>();
            _read = Substitute.For<IRead>();
            _update = Substitute.For<IUpdate>();
            _database = Substitute.For<IMongoDatabase>();
            _bsonDoc = Substitute.For<BsonDocument>();
            _collection = Substitute.For<IMongoCollection<BsonDocument>>();
            _modelClass = Substitute.For<IModelClass>();


        }

        [Fact]
        public void TestClassCreate()
        {
            setupMockPrepository();

            IServiceClass service = new ServiceClass(_create, _delete, _update, _read, _testDatabase);

            _create.CreateCollection(_testDatabase, "testCollection").Returns<IMongoCollection<BsonDocument>>(_collection);

            //cannot mock a concrete class
            _modelClass.ClassBson(_modelClass).Returns(_bsonDoc);

            _create.CreateDocument(_collection, _bsonDoc).Returns<bool>(true);

            var temp = service.CreateClass(_modelClass, "testCollection");

            Assert.True(temp);

            //empty model test
            Assert.Throws<ArgumentNullException>(() => service.CreateClass(null, "testCollection"));

            //empty string collection
            Assert.Throws<ArgumentNullException>(() => service.CreateClass(_modelClass, null));

            //empty collection test
            _create.CreateCollection(_testDatabase, "testCollection").Returns<IMongoCollection<BsonDocument>>( i => null);

            Assert.Throws <ArgumentNullException> (() => service.CreateClass(_modelClass, "testCollection"));

            //return doc is null
            _modelClass.ClassBson(_modelClass).Returns(i => null);
            Assert.Throws <ArgumentNullException> (() => service.CreateClass(_modelClass, "testCollection"));

            ////no doc created
            //_create.CreateDocument(_collection, _bsonDoc).Returns<bool>(false);

            //var temp2 = service.CreateClass(_modelClass, "testCollection");
            //bool v = service.CreateClass(_modelClass, "testCollection");
            //Assert.False(v);

        }

        [Fact]
        public void TestReadAllCollection()
        {
            setupMockPrepository();
            IServiceClass service = new ServiceClass(_create, _delete, _update, _read, _testDatabase);

            //_read.ReadCollection(_testDatabase).Returns<List<string>>(new List<string>());

            _read.ReadCollection(_testDatabase).Returns<List<string>>(l => null);

            Assert.Throws<ArgumentNullException> (() => service.ReadAllCollectionInClass());
        }

        [Fact]
        public void TestUpdate()
        {
            setupMockPrepository();
            IServiceClass service = new ServiceClass(_create, _delete, _update, _read, _testDatabase);

            Assert.Throws<ArgumentNullException>(() => service.UpdateClassName(null, null));

            Assert.Throws<DuplicateDataException>(() => service.UpdateClassName("varun", "varun"));

            //why did this failed with "Class" as database parameter
            _update.UpdateCollectionName(_testDatabase, "test1", "test2").Returns<bool>(true);

            var returnValue = service.UpdateClassName("test1", "test2");

            Assert.True(returnValue);

        }

        [Fact]

        public void TestDelete()
        {
            setupMockPrepository();
            IServiceClass service = new ServiceClass(_create, _delete, _update, _read, _testDatabase);

            Assert.Throws<ArgumentNullException>(() => service.DeleteClass(null));

            _delete.DropCollection(_testDatabase, "newColl").Returns<bool>(true);

            var isDelelted = service.DeleteClass("newColl");

            Assert.True(isDelelted);

        }
    }
}
