using System;
using MongoDB.Bson;
using CRUDModel;
using Newtonsoft.Json;

namespace CRUDModel
{
    public class ModelClass : IModelClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> subjectID { get; set; }

        public IModelClass CreateClass(int id, string name, List<int> subjectID)
        {
            IModelClass modelClass = new ModelClass();
            modelClass.Id = id;
            modelClass.Name = name;
            modelClass.subjectID = subjectID;

            return modelClass;

        }
        public BsonDocument ClassBson(IModelClass modelClass)
        {

            string output = JsonConvert.SerializeObject(modelClass);

            var document = new BsonDocument();

            document.Add(BsonDocument.Parse(output));

            return document;
        }
    }
}
