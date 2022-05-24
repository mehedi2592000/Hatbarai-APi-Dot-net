using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity_Layer.DataModel
{
  public class AgencyModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contacNo { get; set; }
        public string email { get; set; }
        public string imageUrl { get; set; }
        public long balance { get; set; }
    }
}
