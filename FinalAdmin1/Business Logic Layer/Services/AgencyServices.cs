using AutoMapper;
using Business_Entity_Layer.DataModel;
using Data_Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
   public class AgencyServices
    {
        public static List<AgencyModel>GetAllAgency()
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<agency, AgencyModel>())).Map<List<AgencyModel>>(DataAccessFactory.AgencyDataAccess().Get());
            return data;
        }

        public static AgencyModel GetAgency(int id)
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<agency, AgencyModel>())).Map<AgencyModel>(DataAccessFactory.AgencyDataAccess().Get(id));
            return data;
        }

        public static bool EditAgency(AgencyModel e)
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<AgencyModel, agency>())).Map<agency>(e);

            try
            {
                DataAccessFactory.AgencyDataAccess().Edit(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddAgency(AgencyModel e)

        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<AgencyModel, agency>())).Map<agency>(e);

            try
            {
                DataAccessFactory.AgencyDataAccess().Add(data);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool DeleteAgency(int id)
        {
            try
            {
                DataAccessFactory.AgencyDataAccess().Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<AgencyModel> FindAgency(string name)
        {
            var data = DataAccessFactory.AgencyDataAccess().Get().Where(cfg => cfg.name.ToLower().Contains(name.ToLower()));

            var d = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<agency, AgencyModel>())).Map<List<AgencyModel>>(data);
            return d;

        }

        /*

        public static int AgencyTotalmoney()
        {
            int data =(int) DataAccessFactory.AgencyDataAccess().Get().Sum(eg => eg.balance);
            return data;
        }

        public static int AgencyMaxmoney()
        {
            int data = (int)DataAccessFactory.AgencyDataAccess().Get().Max(eg => eg.balance);
            return data;
        }
        */
    }
}
