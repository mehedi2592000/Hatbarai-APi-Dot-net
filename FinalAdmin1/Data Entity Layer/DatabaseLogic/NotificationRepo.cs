using Data_Entity_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Entity_Layer.DatabaseLogic
{
    public class NotificationRepo : irRepojaytory<notification, int>
    {
        FinalEntities db;
        public NotificationRepo(FinalEntities db)
        {
            this.db = db;
        }

        public void Add(notification e)
        {
            db.notifications.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.notifications.FirstOrDefault(cfg => cfg.id == id);
            db.notifications.Remove(data);
            db.SaveChanges();
        }

        public void Edit(notification e)
        {
            var data = db.notifications.FirstOrDefault(cfg => cfg.id == e.id);
            db.Entry(data).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<notification> Get()
        {
            return db.notifications.ToList();
        }

        public notification Get(int id)
        {
            return db.notifications.FirstOrDefault(ef => ef.id == id);
        }
    }
}
