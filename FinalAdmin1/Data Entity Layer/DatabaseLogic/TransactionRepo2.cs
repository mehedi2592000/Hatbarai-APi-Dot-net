using Data_Entity_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Entity_Layer.DatabaseLogic
{
    public class TransactionRepo2 : Transaction2
    {
        FinalEntities db;
        public TransactionRepo2(FinalEntities db)
        {
            this.db = db;
        }
        public List<transaction> Tran()
        {
            return db.transactions.Where(e => e.type.Equals("utoa")).ToList();

           

        }

        public List<transaction> Pan()
        {
            return db.transactions.Where(e => e.reciverid.Equals(null)).ToList();



        }


        public List<transaction> Vtoa()
        {
            return db.transactions.Where(e => e.type.Equals("vtoa")).ToList();
        }
    }
}
