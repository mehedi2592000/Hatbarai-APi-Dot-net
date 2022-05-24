using Data_Entity_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Entity_Layer.DatabaseLogic
{
    public class TransactionRepo : irRepojaytory<transaction, int>
    {
        FinalEntities db;
        public TransactionRepo(FinalEntities db)
        {
            this.db = db;
        }
        public void Add(transaction e)
        {
            db.transactions.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var q = db.transactions.FirstOrDefault(ef => ef.id == id);
            db.transactions.Remove(q);
            db.SaveChanges();
        }

        public void Edit(transaction e)
        {
            var q = db.transactions.FirstOrDefault(ef => ef.id == e.id);
            db.Entry(q).CurrentValues.SetValues(e);
            db.SaveChanges();

        }

        public List<transaction> Get()
        {
            return db.transactions.ToList();
        }

        public transaction Get(int id)
        {
            return db.transactions.FirstOrDefault(ef => ef.id == id);
        }

        public List<transaction>Money()
        {
            return db.transactions.Where(e => e.type.Equals("utoa")).ToList();
        }
    }
}
