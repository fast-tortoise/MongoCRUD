
using CRUDBusiness;
using Microsoft.Extensions.Configuration;
using CRUDRepository;
using Microsoft.Extensions.Configuration.Json;
using CRUDModel;

namespace Varun
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();

            string connection = config["connectionString"];
            string databaseClass = config["databaseClass"];
            string databaseSchool = config["databaseSubject"];

            ICreate create = new CreateRepository(connection);
            IDelete delete = new DeleteRepository(connection);
            IUpdate update = new UpdateRepository(connection);
            IRead read = new ReadRepository(connection);
            IServiceClass @class = new ServiceClass(create, delete, update, read, databaseClass);
            IServiceSubject subject = new ServiceSubject(create, delete, update, read, databaseSchool);

            GetRequest(@class, subject);
        }

        public static void GetRequest(IServiceClass @class, IServiceSubject subject) {

            while (true)
            {
                Console.WriteLine("1. Create Class");
                Console.WriteLine("2. Read All Collection In Class");
                Console.WriteLine("3. Update Class Name");
                Console.WriteLine("4. Delete Class Collection");
                Console.WriteLine("5. Create Subject");
                Console.WriteLine("6. Read All Collection In Subject");
                Console.WriteLine("7. Update Subject Name");
                Console.WriteLine("8. Delete Subject Collection");

                string? key = Console.ReadLine();

                if (key == null) break;
                if (int.Parse(key) > 8) Console.WriteLine("Out of limits");

                ProcessRequest(key, @class, subject);
            } 
            
        }
        public static void ProcessRequest(string key, IServiceClass @class, IServiceSubject subject) {

            if (key == "1") CreateClass(@class);
            
            else if (key == "2") ReadAllCollectionInClass(@class);
            
            else if (key == "3") UpdateClassName(@class);
            
            else if (key == "4") DeleteClass(@class);
            
            else if (key == "5") CreateSubject(subject);
            
            else if (key == "6") ReadAllCollectionInSubject(subject);
            
            else if (key == "7") UpdateSubjectName(subject);
            
            else if (key == "8") DeleteSubject(subject);
            
            
        }
        public static void CreateClass(IServiceClass @class)
        {
            Console.WriteLine("ClassID");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter className");
            string name = Console.ReadLine();

            Console.WriteLine("Enter comma seperated subjectIDs.");
            string subjectID = Console.ReadLine();
            List<int> subjectIDs = subjectID.Split(' ').Select(int.Parse).ToList();

            IModelClass modelClass = new ModelClass();

            var modelclass = modelClass.CreateClass(id, name, subjectIDs);
            @class.CreateClass(modelclass,  "ClassCollection");
            

        }
        public static void ReadAllCollectionInClass(IServiceClass @class)
        {
            var listOfCollections = @class.ReadAllCollectionInClass();

            foreach (var collection in listOfCollections)
                Console.WriteLine(collection);
        }
        public static void UpdateClassName(IServiceClass @class)
        {
            ReadAllCollectionInClass(@class);

            Console.WriteLine("Current name of the class");
            string oldCollection = Console.ReadLine();

            Console.WriteLine("Enter new Name");
            string newName = Console.ReadLine();

            @class.UpdateClassName(oldCollection, newName);

        }
        public static void DeleteClass(IServiceClass @class)
        {
            Console.WriteLine("Enter class to be deleted");
            string deleteClass = Console.ReadLine();

            @class.DeleteClass(deleteClass);
        }
        public static void CreateSubject(IServiceSubject subject)
        {
            Console.WriteLine("ClassID");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter subjectName");
            string name = Console.ReadLine();

            Console.WriteLine("Enter comma seperated classIDs.");
            string classID = Console.ReadLine();
            List<int> subClassID = classID.Split(' ').Select(int.Parse).ToList();

            Console.WriteLine("Enter comma seperated chapterNames.");
            string chapterName = Console.ReadLine();
            List<string> chapterNames = chapterName.Split(' ').ToList();

            Console.WriteLine("Enter comma seperated classID for each chapter.");
            string chapterClassId = Console.ReadLine();
            List<int> chapterClassIds = chapterClassId.Split(' ').Select(int.Parse).ToList();

            ModelSubject modelSubject = new ModelSubject(id, name, subClassID, chapterNames, chapterClassIds);

            subject.CreateSubject(modelSubject, "SchoolConnection");


        }
        public static void ReadAllCollectionInSubject(IServiceSubject subject)
        {
            var listOfCollections = subject.ReadSubjects();
            Console.WriteLine(listOfCollections);
        }
        public static void UpdateSubjectName(IServiceSubject subject)
        {
            Console.WriteLine("Current name of the subject");
            string oldCollection = Console.ReadLine();

            Console.WriteLine("Enter new Name");
            string newName = Console.ReadLine();

            subject.UpdateSubjectName(oldCollection, newName);

        }
        public static void DeleteSubject(IServiceSubject subject)
        {
            Console.WriteLine("Enter class to be deleted");
            string deleteSubject = Console.ReadLine();

            subject.DeleteSubject(deleteSubject);
        }

    }

}
