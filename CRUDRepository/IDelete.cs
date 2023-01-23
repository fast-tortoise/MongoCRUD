namespace CRUDRepository
{
    public interface IDelete
    {
        void DeleteDocument(string deleteFromDatabase, string deleteFromCollection);
        bool DropCollection(string dbName, string collection);
        void DropDatabase(string dbName);
    }
}