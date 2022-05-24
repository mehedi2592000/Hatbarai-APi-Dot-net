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
    public class NotificationServices
    {
        public static List<NotificationModel>GetAllNotification()
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<notification, NotificationModel>())).Map<List<NotificationModel>>(DataAccessFactory.NotificationDataAccess().Get());
            return data;
        }

        public static NotificationModel GetindexNotification(int id)
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<notification, NotificationModel>())).Map<NotificationModel>(DataAccessFactory.NotificationDataAccess().Get(id));
            return data;
        }

        public static bool AddedMessage(NotificationModel n)
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<NotificationModel, notification>())).Map<notification>(n);
            try
            {
                DataAccessFactory.NotificationDataAccess().Add(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteMeesga(int id)
        {
            try
            {
                DataAccessFactory.NotificationDataAccess().Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool EditMessage(NotificationModel n)
        {
            var data = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<NotificationModel, notification>())).Map<notification>(n);
                
            try
            {
                DataAccessFactory.NotificationDataAccess().Edit(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<NotificationModel> FindNotification()
        {
            var data = DataAccessFactory.NotificationDataAccess().Get().Where(eg => eg.type !="atoall" && eg.receiverid==null);
            var dat = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<notification, NotificationModel>())).Map<List<NotificationModel>>(data);
            return dat;
        }


    }
}
