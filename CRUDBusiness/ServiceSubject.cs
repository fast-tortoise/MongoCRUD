using CRUDModel;
using CRUDRepository;
using MongoDB.Driver;

namespace CRUDBusiness
{
    public class ServiceSubject : IServiceSubject
    {
        private ICreate _create;
        private IDelete _delete;
        private IUpdate _update;
        private IRead _read;
        private string _database;
        public ServiceSubject(ICreate create, IDelete delete, IUpdate update, IRead read, string database)
        {
            _create = create;
            _delete = delete;
            _update = update;
            _read = read;
        }

        public void CreateSubject(ModelSubject model, string collection)
        {
            var collectionn = _create.CreateCollection(_database, collection);
            var bsonDoc = model.SubjectBson(model);

            _create.CreateDocument(_database, collection, bsonDoc);

        }

        public List<string> ReadSubjects()
        {
            var collections = _read.ReadCollection(_database);

            return collections;
        }

        public void UpdateSubjectName(string oldCollection, string newName)
        {
            _update.UpdateCollectionName(_database, oldCollection, newName);
        }

        public void DeleteSubject(string subjectToBeRemoved)
        {
            _delete.DropCollection(_database, subjectToBeRemoved);
        }

    }
}