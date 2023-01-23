using CRUDModel;

namespace CRUDBusiness
{
    public interface IServiceSubject
    {
        void CreateSubject(ModelSubject model, string collection);
        void DeleteSubject(string subjectToBeRemoved);
        List<string> ReadSubjects();
        void UpdateSubjectName(string oldCollection, string newName);
    }
}