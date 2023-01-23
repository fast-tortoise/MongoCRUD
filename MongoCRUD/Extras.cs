using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCRUD
{
    internal class Extras
    {

        //public static void CreateDocument(Read read)
        //{
        //    Console.WriteLine("Select Databse");
        //    var databaseNames = read.ReadAllDatabase();
        //    foreach (var databaseName in databaseNames)
        //    {
        //        Console.WriteLine(databaseName);
        //    }
        //    string database = Console.ReadLine();

        //    var collections = read.ReadCollection(database);

        //    foreach (var collection in collections)
        //    {
        //        Console.WriteLine(collection);
        //    }
        //    Console.WriteLine("Enter collection to write document in");


        //}
        //public static void CreateDocumentInClassCollection(Read read, Create create, ChangeToBSON changeToBSON)
        //{
        //    Console.WriteLine("Select Databse");
        //    var databaseNames = read.ReadAllDatabase();
        //    foreach (var databaseName in databaseNames)
        //    {
        //        Console.WriteLine(databaseName);
        //    }
        //    string database = Console.ReadLine();

        //    var collections = read.ReadCollection(database);

        //    foreach (var collection in collections)
        //    {
        //        Console.WriteLine(collection);
        //    }
        //    Console.WriteLine("Enter collection to write document in");
        //    string collectionTo = Console.ReadLine();

        //    Console.WriteLine("Enter class name");
        //    string @class = Console.ReadLine();

        //    Console.WriteLine("Enter the subjectIDs in spaced input.");
        //    string subject = Console.ReadLine();

        //    List<int> listOfSubject = subject.Split(' ').Select(int.Parse).ToList();

        //    var document = changeToBSON.ClassBson(@class, listOfSubject);

        //    create.CreateDocument(database, collectionTo, document);
        //}
        //public static void CreateDocumentInSubjectCollection(Read read, Create create, ChangeToBSON changeToBSON)
        //{
        //    Console.WriteLine("Select Databse");
        //    var databaseNames = read.ReadAllDatabase();
        //    foreach (var databaseName in databaseNames)
        //    {
        //        Console.WriteLine(databaseName);
        //    }
        //    string database = Console.ReadLine();

        //    var collections = read.ReadCollection(database);

        //    foreach (var collection in collections)
        //    {
        //        Console.WriteLine(collection);
        //    }
        //    Console.WriteLine("Enter collection to write document in");
        //    string collectionTo = Console.ReadLine();

        //    Console.WriteLine("Enter SubName");
        //    string subName = Console.ReadLine();

        //    Console.WriteLine("Enter classIds");
        //    string classIDs = Console.ReadLine();
        //    List<int> listClassIDs = classIDs.Split(' ').Select(int.Parse).ToList();

        //    //---------------------------------------------------------------add chapter
        //    Console.WriteLine("Enter list of chapterName");
        //    string chapterNames = Console.ReadLine();
        //    List<string> listChapterNames = chapterNames.Split(' ').ToList();

        //    Console.WriteLine("Enter chapter ids");
        //    string chapterIds = Console.ReadLine();
        //    List<int> listChapterIDs = chapterIds.Split(' ').Select(int.Parse).ToList();
        //    var document = changeToBSON.SubjectBson(subName, listClassIDs, listChapterNames, listChapterIDs);

        //    create.CreateDocument(database, collectionTo, document);


        //}
        //public static void ReadAllDatabaseAndCollectionsInIt(Read read)
        //{
        //    var databaseNames = read.ReadAllDatabase();

        //    foreach (var databaseName in databaseNames)
        //    {
        //        Console.WriteLine(databaseName);
        //    }
        //    Console.WriteLine("");
        //    Console.WriteLine("Enter databse to read from");
        //    string database = Console.ReadLine();

        //    var collections = read.ReadCollection(database);
        //    Console.WriteLine("");
        //    foreach (var collection in collections)
        //    {
        //        Console.WriteLine(collection);
        //    }
        //}
        //public static void ReadAllCollections(Read read)
        //{
        //    var databaseNames = read.ReadAllDatabase();

        //    foreach (var databaseName in databaseNames)
        //    {
        //        var collections = read.ReadCollection(databaseName);
        //        Console.WriteLine("");
        //        foreach (var collection in collections)
        //        {
        //            Console.WriteLine(databaseName + " " + collection);
        //        }

        //    }

        //}
        //public static void ReadDocumentFromCollection(Read read)
        //{
        //    Console.WriteLine("Select Databse");
        //    var databaseNames = read.ReadAllDatabase();
        //    foreach (var databaseName in databaseNames)
        //    {
        //        Console.WriteLine(databaseName);
        //    }
        //    string database = Console.ReadLine();

        //    var collections = read.ReadCollection(database);

        //    foreach (var collection in collections)
        //    {
        //        Console.WriteLine(collection);
        //    }
        //    Console.WriteLine("Enter collection to read from");
        //    string collectionFrom = Console.ReadLine();

        //    var documents = read.ReadDocuments(database, collectionFrom);

        //    foreach (BsonDocument doc in documents)
        //    {
        //        Console.WriteLine(doc.ToString());
        //    }

        //}
        //public static void ReadDocumentByFilter(Read read)
        //{
        //    Console.WriteLine("Select Databse");
        //    var databaseNames = read.ReadAllDatabase();
        //    foreach (var databaseName in databaseNames)
        //    {
        //        Console.WriteLine(databaseName);
        //    }
        //    string database = Console.ReadLine();

        //    var collections = read.ReadCollection(database);

        //    foreach (var collection in collections)
        //    {
        //        Console.WriteLine(collection);
        //    }
        //    Console.WriteLine("Enter collection to read from");
        //    string collectionFrom = Console.ReadLine();

        //    Console.WriteLine("Enter document id key");
        //    string key = Console.ReadLine();

        //    Console.WriteLine("Enter document id");
        //    int value = Convert.ToInt32(Console.ReadLine());

        //    var document = read.ReadDocumentByID(database, collectionFrom, key, value);

        //    Console.WriteLine(document.ToString());
        //}
        //public static void UpdateCollectionName(Read read, Update update)
        //{
        //    Console.WriteLine("Select Database");
        //    var databaseNames = read.ReadAllDatabase();
        //    foreach (var databaseName in databaseNames)
        //    {
        //        Console.WriteLine(databaseName);
        //    }
        //    string database = Console.ReadLine();

        //    var collections = read.ReadCollection(database);

        //    foreach (var collection in collections)
        //    {
        //        Console.WriteLine(collection);
        //    }
        //    Console.WriteLine("Enter collection");
        //    string Oldcollection = Console.ReadLine();

        //    Console.WriteLine("Enter new name");
        //    string newName = Console.ReadLine();

        //    update.UpdateCollectionName(database, Oldcollection, newName);

        //}
        //public static void UpdateValueOfAKey(Read read, Update update)
        //{
        //    Console.WriteLine("Select Database");
        //    var databaseNames = read.ReadAllDatabase();
        //    foreach (var databaseName in databaseNames)
        //    {
        //        Console.WriteLine(databaseName);
        //    }
        //    string database = Console.ReadLine();

        //    var collections = read.ReadCollection(database);

        //    foreach (var collection in collections)
        //    {
        //        Console.WriteLine(collection);
        //    }
        //    Console.WriteLine("Enter collection");
        //    string collectionToUpdate = Console.ReadLine();

        //    Console.WriteLine("Enter keyid to be searched");
        //    string key = Console.ReadLine();

        //    Console.WriteLine("Enter key value");
        //    int value = Convert.ToInt32(Console.ReadLine());

        //    Console.WriteLine("Enter key whole value has to be changed");
        //    var keyToProcess = Console.ReadLine();

        //    Console.WriteLine("Enter new value");
        //    //this is a limitation
        //    int valueToEnter = Convert.ToInt32(Console.ReadLine());

        //    update.UpdateData(database, collectionToUpdate, key, value, keyToProcess, valueToEnter);

        //}
        //public static void DeleteCollection(Read read, Delete delete)
        //{
        //    Console.WriteLine("Select Databse");
        //    var databaseNames = read.ReadAllDatabase();
        //    foreach (var databaseName in databaseNames)
        //    {
        //        Console.WriteLine(databaseName);
        //    }
        //    string database = Console.ReadLine();

        //    var collections = read.ReadCollection(database);

        //    foreach (var collection in collections)
        //    {
        //        Console.WriteLine(collection);
        //    }
        //    Console.WriteLine("Select collection");

        //    string collectionToBeDeleted = Console.ReadLine();

        //    delete.DropCollection(database, collectionToBeDeleted);

        //}
        //public static void DeleteDocument()
        //{

        //}

        //trail code
        //public void AddKeyValuePairToDoc(string updateInDatabase, string updateInCollection, string key, int value, string updateKey, List<int> updateValue)
        //{
        //    var database = client.GetDatabase(updateInDatabase);

        //    var collection = database.GetCollection<BsonDocument>(updateInCollection);

        //    var filter = Builders<BsonDocument>.Filter.Eq(key, value);

        //    var docoriginal = collection.Find<BsonDocument>(filter);

        //    var document = new BsonDocument
        //    {
        //        { "student_id", 10000 },
        //        { "scores", new BsonArray
        //            {
        //            new BsonDocument{ {"type", "exam"}, {"score", 88.12334193287023 } },
        //            new BsonDocument{ {"type", "quiz"}, {"score", 74.92381029342834 } },
        //            new BsonDocument{ {"type", "homework"}, {"score", 89.97929384290324 } },
        //            new BsonDocument{ {"type", "homework"}, {"score", 82.12931030513218 } }
        //            }
        //        },
        //        { "class_id", 480}
        //    };

        //    var json1 = docoriginal.ToJson(new MongoDB.Bson.IO.JsonWriterSettings());
        //    var json2 = document.ToJson(new MongoDB.Bson.IO.JsonWriterSettings());

        //    var jsonFinal = json1 + json2;


        //}
    }
}
