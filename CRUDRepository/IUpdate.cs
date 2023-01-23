namespace CRUDRepository
{
    public interface IUpdate
    {
        bool UpdateCollectionName(string updateInDatabase, string OldName, string NewName);
        void UpdateData(string updateInDatabase, string updateInCollection, string key, int value, string updateKey, int updateValue);
        void updateIDList(string updateInDatabase, string updateInCollection, string key, int value, string updateKey, List<int> updateValue);
    }
}