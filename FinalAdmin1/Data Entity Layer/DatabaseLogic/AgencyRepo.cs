using Data_Entity_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Entity_Layer.DatabaseLogic
{
    public class AgencyRepo : irRepojaytory<agency, int>
    {
        FinalEntities db;

        public AgencyRepo(FinalEntities db)
        {
            this.db = db;
        }

        public void Add(agency e)
        {
            db.agencies.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var d = db.agencies.FirstOrDefault(er => er.id == id);
            db.agencies.Remove(d);
            db.SaveChanges();
        }

        public void Edit(agency e)
        {
            var d = db.agencies.FirstOrDefault(er => er.id == e.id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<agency> Get()
        {
            return db.agencies.ToList();
        }

        public agency Get(int id)
        {
            return db.agencies.FirstOrDefault(er => er.id == id);
        }
    }
}
