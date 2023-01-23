using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using CRUDModel;
using Newtonsoft.Json;

namespace CRUDModel
{
    public class ModelSubject
    {
        private int _id { get; set; }
        private string _name { get; set; }
        private List<int> _classID { get; set; }

        public List<ModelChapter> _modelChapter = new List<ModelChapter>();

        public ModelSubject(int id, string name, List<int> subClassID, List<string> chapterName, List<int> chapterClassId)
        {
            _id = id;
            _name = name;
            _classID = subClassID;
            for (int i = 0; i < chapterName.Count(); i++)
            {
                var modelChapter = new ModelChapter(1, chapterName[i], chapterClassId[i]);
                _modelChapter.Add(modelChapter);
            }
        }

        public BsonDocument SubjectBson(ModelSubject modelSubject)
        {

            string output = JsonConvert.SerializeObject(modelSubject);

            var document = new BsonDocument();

            document.Add(BsonDocument.Parse(output));

            return document;
        }
    }
}
