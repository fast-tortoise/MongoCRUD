using System;
using CRUDModel;
using CRUDRepository;
using Exceptions;

namespace CRUDBusiness
{

    public class ServiceClass : IServiceClass
    {
        private ICreate _create;
        private IDelete _delete;
        private IUpdate _update;
        private IRead _read;
        private string _database;

        public ServiceClass(ICreate create, IDelete delete, IUpdate update, IRead read, string database)
        {
            _create = create;
            _delete = delete;
            _update = update;
            _read = read;
            _database = database;
        }
        public bool CreateClass(IModelClass modelClass, string collection)
        {
            if(modelClass == null)
                throw new ArgumentNullException(nameof(modelClass));

            if(collection == null)
                throw new ArgumentNullException(nameof(collection));

            var mycollection = _create.CreateCollection(_database, collection);

            if (mycollection == null) { throw new ArgumentNullException(nameof(mycollection)); }

            var bsonDoc = modelClass.ClassBson(modelClass);

            if (bsonDoc == null) { throw new ArgumentNullException(nameof(bsonDoc)); }  

            var isDocCreated = _create.CreateDocument(mycollection, bsonDoc);

            return isDocCreated;
        }

        public List<string> ReadAllCollectionInClass()
        {
            var collections = _read.ReadCollection(_database);
            if (collections == null) 
            { 
                throw new ArgumentNullException(nameof(collections)); 
            }

            return collections;
        }

        public bool UpdateClassName(string oldCollection, string newName)
        {
            if (oldCollection == null || newName == null)
            {
                throw new ArgumentNullException("Empty values can't be updated");
                
            }
            if (oldCollection == newName)
            {
                throw new DuplicateDataException("OldCollection name is same as new one, no update required");
                
            }
            var isUpdated = _update.UpdateCollectionName(_database, oldCollection, newName);

            return isUpdated;
        }

        public bool DeleteClass(string classToBeRemoved)
        {
            if (classToBeRemoved == null)
                throw new ArgumentNullException("ClassName is null");

            var deleteResult = _delete.DropCollection(_database, classToBeRemoved);

            return deleteResult;
            
        }

        
    }
}
