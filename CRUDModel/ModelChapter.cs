using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDModel
{
    public class ModelChapter
    {
        private int _number { get; set; }
        private string _name { get; set; }
        private int _classID { get; set; }
        public ModelChapter(int number, string name, int classID)
        {
            _number = number;
            _name = name;
            _classID = classID;
        }
    }

    
}
