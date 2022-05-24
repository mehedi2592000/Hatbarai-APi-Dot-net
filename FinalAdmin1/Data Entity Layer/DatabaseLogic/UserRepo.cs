using Data_Entity_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Entity_Layer.DatabaseLogic
{
    public class UserRepo : irRepojaytory<user, int>
    {
        FinalEntities db;
        public UserRepo(FinalEntities db)
        {
            this.db = db;
        }
        public void Add(user e)
        {
            db.users.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var delete = db.users.FirstOrDefault(e => e.id == id);
            db.users.Remove(delete);
            db.SaveChanges();

        }

        public void Edit(user e)
        {
            var edit = db.users.FirstOrDefault(ef => ef.id == e.id);
            db.Entry(edit).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<user> Get()
        {
            return db.users.ToList();
        }

        public user Get(int id)
        {
            return db.users.FirstOrDefault(e => e.id == id);
        }
    }
}
