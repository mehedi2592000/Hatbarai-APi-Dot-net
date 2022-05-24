using Data_Entity_Layer.DatabaseLogic;
using Data_Entity_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Entity_Layer
{
   public class DataAccessFactory
    {
        static FinalEntities db;
        static DataAccessFactory()
        {
            db = new FinalEntities();
        }

        public static irRepojaytory<user,int>UserDataAccess()
        {
            return new UserRepo(db);
        }
        public static irRepojaytory<orphan,int>OrphanDataAccess()
        {
            return new OrphanRepo(db);
        }
        public static irRepojaytory<agency,int>AgencyDataAccess()
        {
            return new AgencyRepo(db);
        }
        public static irRepojaytory<transaction, int> TransationDataAccess()
        {
            return new TransactionRepo(db);
        }
        public static irRepojaytory<notification,int>NotificationDataAccess()
        {
            return new NotificationRepo(db);
        }
        public static iAuth AuthDataAccess()
        {
            return new AuthRepo(db);
        }
        public static Transaction2 AuthTransaction2()
        {
            return new TransactionRepo2(db);
        }
    }
}
