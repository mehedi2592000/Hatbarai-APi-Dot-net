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
    public class UserServices
    {
        public static List<UserModel>GetallUser()
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<user, UserModel>())).Map<List<UserModel>>(DataAccessFactory.UserDataAccess().Get());
            return data;
        }
        public static UserModel GetUser(int id)
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<user, UserModel>())).Map<UserModel>(DataAccessFactory.UserDataAccess().Get(id));
            return data;
        }

        public static bool EditUser(UserModel e)
        {
            var data = new Mapper(new MapperConfiguration(cfgg => cfgg.CreateMap<UserModel, user>())).Map<user>(e);
            try
            {
                DataAccessFactory.UserDataAccess().Edit(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Adduser(UserModel e)
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserModel, user>())).Map<user>(e);
            try
            {
                DataAccessFactory.UserDataAccess().Add(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Deleteuser(int id)
        {
            try
            {
                DataAccessFactory.UserDataAccess().Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool checkEmailAvailable(string email)
        {
            try
            {
                var data = DataAccessFactory.UserDataAccess().Get().FirstOrDefault(c => c.email.Contains(email));
                if(data!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static List<UserModel>GetAllVolunteer()
        {
            var d = DataAccessFactory.UserDataAccess().Get().Where(en => en.role.Contains("volunteer"));

            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<user,UserModel>())).Map<List<UserModel>>(d);
            return data;
           
        }
        public static List<UserModel> GetAllAgency()
        {
            var d = DataAccessFactory.UserDataAccess().Get().Where(en => en.role.Contains("agency"));

            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<user, UserModel>())).Map<List<UserModel>>(d);
            return data;

        }
        public static List<UserModel> GetAlluse()
        {
            var d = DataAccessFactory.UserDataAccess().Get().Where(en => en.role.Contains("user"));

            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<user, UserModel>())).Map<List<UserModel>>(d);
            return data;

        }

        public static int TotalVolunteer()
        {
            int d = DataAccessFactory.UserDataAccess().Get().Where(en => en.role.Contains("volunteer")).Count();
            
            return d;
        }
        public static int TotalUser()
        {
            int d = DataAccessFactory.UserDataAccess().Get().Where(en => en.role.Contains("user")).Count();
            return d;
        }
        public static int TotalAgency()
        {
            int d = DataAccessFactory.UserDataAccess().Get().Where(en => en.role.Contains("agency")).Count();
            return d;
        }


        public static int Totalmoneyadmin()
        {
            int d = (int)DataAccessFactory.UserDataAccess().Get().Where(en => en.role.Contains("admin")).Sum(en=>en.balance);
            return d;
        }
    }
}
