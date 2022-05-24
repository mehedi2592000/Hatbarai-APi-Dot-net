using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity_Layer.DataModel
{
   public class OrphanModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string contactNo { get; set; }
        public string address { get; set; }
        public bool isAccepted { get; set; }
        public Nullable<int> aid { get; set; }
        public Nullable<int> vid { get; set; }
    }
}
