using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCRUD.Model
{
    public class ModelClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> subjectID { get; set; }

    }

}
