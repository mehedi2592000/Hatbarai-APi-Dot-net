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
   public class TransactionServices
    {
        public static List<TransactionModel>GetAllTransction()
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<transaction, TransactionModel>())).Map<List<TransactionModel>>(DataAccessFactory.TransationDataAccess().Get());
            return data;
        }

        public static TransactionModel GetindexTransction(int id)
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<transaction, TransactionModel>())).Map<TransactionModel>(DataAccessFactory.TransationDataAccess().Get(id));
            return data;
        }

        public static bool EditTransaction(TransactionModel e)
        {

            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TransactionModel, transaction>())).Map<transaction>(e);
            try
            {
                DataAccessFactory.TransationDataAccess().Edit(data);
                return true;
            }
            catch
            {
                return false;
            }

        
        }

        public static bool AddAdminTranscationtoAdmin(TransactionModel e)
        {

            //var admin = DataAccessFactory.UserDataAccess().Get().FirstOrDefault(ef => ef.role.Contains("admin"));
            var admin = DataAccessFactory.UserDataAccess().Get().FirstOrDefault(ef => ef.id==1);
            admin.balance += e.amount;
            DataAccessFactory.UserDataAccess().Edit(admin);
            
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TransactionModel, transaction>())).Map<transaction>(e);
            try
            {
                DataAccessFactory.TransationDataAccess().Add(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteTranscation(int id)
        {
            try
            {
                DataAccessFactory.TransationDataAccess().Delete(id);
                return true;

            }
            catch
            {
                return false;
            }
        }
        public static List<TransactionModel> RequesttoAgencyPeople()
        {
            //var data = DataAccessFactory.TransationDataAccess().Get().Where(cfg => cfg.reciverid == 0);
           // var data = DataAccessFactory.TransationDataAccess().Get().Where(cfg =>cfg.reciverid.Equals(null));
            var dat = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<transaction, TransactionModel>())).Map<List<TransactionModel>>(DataAccessFactory.AuthTransaction2().Pan());
            return dat;
        }
      
        public static bool RequestExaccapted(TransactionModel t)
        {
            var admin = DataAccessFactory.UserDataAccess().Get().FirstOrDefault(ef => ef.role.Contains("admin"));
            admin.balance -= t.amount;
            DataAccessFactory.UserDataAccess().Edit(admin);
            var agen = DataAccessFactory.UserDataAccess().Get().FirstOrDefault(ef => ef.role.Contains("agency"));
            agen.balance += t.amount;
            DataAccessFactory.UserDataAccess().Edit(agen);
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TransactionModel, transaction>())).Map<transaction>(t);
            try
            {
                DataAccessFactory.TransationDataAccess().Edit(data);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static List<TransactionModel>GetUsertoAdminmoneyList()
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<transaction, TransactionModel>())).Map<List<TransactionModel>>(DataAccessFactory.AuthTransaction2().Tran());
            return data;
        }
        public static int TotalusertoadminModeney()
        {
            // var data = DataAccessFactory.TransationDataAccess().Get().Where(eg => eg.type.Equals("utoa"));
            // int st = (int)data.Sum(es => es.amount);

            int st = (int)DataAccessFactory.AuthTransaction2().Tran().Sum(e => e.amount);

            return st;
        }
        

        public static int HightuserMoney()
        {
            int st = (int)DataAccessFactory.AuthTransaction2().Tran().Max(e => e.amount);
            return st;
        }

        public static List<TransactionModel> GetvolunteertoAdminmoneyList()
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<transaction, TransactionModel>())).Map<List<TransactionModel>>(DataAccessFactory.AuthTransaction2().Vtoa());
            return data;
        }
        public static int TotalvolunteertoadminMoney()
        {
            // var data = DataAccessFactory.TransationDataAccess().Get().Where(eg => eg.type.Equals("utoa"));
            // int st = (int)data.Sum(es => es.amount);

            int st = (int)DataAccessFactory.AuthTransaction2().Vtoa().Sum(e => e.amount);

            return st;
        }
    }
}
