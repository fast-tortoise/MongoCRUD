using CRUDModel;

namespace CRUDBusiness
{
    public interface IServiceClass
    {
        bool CreateClass(IModelClass modelClass, string collection);
        bool DeleteClass(string classToBeRemoved);
        List<string> ReadAllCollectionInClass();
        bool UpdateClassName(string oldCollection, string newName);
    }
}