using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity_Layer.DataModel
{
    public class NotificationModel
    {
        public int id { get; set; }
        public string type { get; set; }
        public string message { get; set; }
        public string title { get; set; }
        public System.DateTime date { get; set; }
        public int senderid { get; set; }
        public Nullable<int> receiverid { get; set; }
    }
}
