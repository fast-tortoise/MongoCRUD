using MongoDB.Bson;
using CRUDModel;
using Newtonsoft.Json;

namespace CRUDRepository
{
    public class ChangeToBSON
    {
        public BsonDocument ClassBson(string Name, List<int> subjects)
        {
            ModelClass modelClass = new ModelClass();
            modelClass.Id = 11;
            modelClass.Name = Name;
            modelClass.subjectID = subjects;

            string output = JsonConvert.SerializeObject(modelClass);

            var document = new BsonDocument();

            document.Add(BsonDocument.Parse(output));

            return document;
        }

        public ModelChapter ChapterBson(string Name, int classID)
        {
            ModelChapter chapter = new ModelChapter();
            chapter.Number = 1;
            chapter.Name = Name;
            chapter.classID = classID;
            return chapter;

        }

        public BsonDocument SubjectBson(string Name, List<int> classID, List<string> chapterName,List<int> classId)
        {
            ModelSubject modelSubject = new ModelSubject();
            modelSubject.Id = 1;
            modelSubject.Name = Name;
            modelSubject.classID = classID;
            for(int i = 0; i<chapterName.Count(); i++)
            {
                var modelChapter = ChapterBson(chapterName[i], classId[i]);
                modelSubject.modelChapter.Add(modelChapter);
            }

            string output = JsonConvert.SerializeObject(modelSubject);
            var document = new BsonDocument();
            document.Add(BsonDocument.Parse(output));
            return document;

        }

        
    }
}
