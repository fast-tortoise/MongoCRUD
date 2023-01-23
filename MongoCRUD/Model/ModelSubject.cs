using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCRUD.Model
{
    public class ModelSubject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> classID { get; set; }

        public List<ModelChapter> modelChapter = new List<ModelChapter>();

    }
}
