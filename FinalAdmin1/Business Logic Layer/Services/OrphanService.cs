using Business_Entity_Layer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data_Entity_Layer;

namespace Business_Logic_Layer.Services
{
   public  class OrphanService
    {
        public static List<OrphanModel>GetAllOrphan()
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<orphan, OrphanModel>())).Map<List<OrphanModel>>(DataAccessFactory.OrphanDataAccess().Get());
            return data;
        }
        public static OrphanModel GetAllOrphan(int id)
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<orphan, OrphanModel>())).Map<OrphanModel>(DataAccessFactory.OrphanDataAccess().Get(id));
            return data;
        }

        public static bool EditOrphan(OrphanModel e)
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<OrphanModel, orphan>())).Map<orphan>(e);
            try
            {
                DataAccessFactory.OrphanDataAccess().Edit(data);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool AddOrphan(OrphanModel e)
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<OrphanModel, orphan>())).Map<orphan>(e);
            try
            {
                DataAccessFactory.OrphanDataAccess().Add(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteOrphan(int id)
        {
            try
            {
                DataAccessFactory.OrphanDataAccess().Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int TotalOrphan()
        {
            int q = DataAccessFactory.OrphanDataAccess().Get().Max(e => e.id);
            return q;
        }

        public static List<OrphanModel>SearchnameOrphan(string name)
        {
            var d = DataAccessFactory.OrphanDataAccess().Get().Where(en => en.name.ToLower().Contains(name.ToLower()));
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<orphan, OrphanModel>())).Map<List<OrphanModel>>(d);
            return data;
        }
    }
}
