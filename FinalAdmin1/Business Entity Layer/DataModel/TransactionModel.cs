using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity_Layer.DataModel
{
    public class TransactionModel
    {
        public int id { get; set; }
        public Nullable<int> donatorid { get; set; }
        public Nullable<int> reciverid { get; set; }
        public string type { get; set; }
        public System.DateTime date { get; set; }
        public long amount { get; set; }
    }
}
