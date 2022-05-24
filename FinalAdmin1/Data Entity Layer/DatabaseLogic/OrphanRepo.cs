using Data_Entity_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Entity_Layer.DatabaseLogic
{
    public class OrphanRepo:irRepojaytory<orphan,int>
    {
        FinalEntities db;
        public  OrphanRepo(FinalEntities db)
        {
            this.db = db;
        }

        public void Add(orphan e)
        {
            db.orphans.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.orphans.FirstOrDefault(en => en.id == id);
            db.orphans.Remove(e);
            db.SaveChanges();
        }

        public void Edit(orphan e)
        {
            var p = db.orphans.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<orphan> Get()
        {
            return db.orphans.ToList();
        }

        public orphan Get(int id)
        {
            return db.orphans.FirstOrDefault(em => em.id == id);
        }
    }
}
