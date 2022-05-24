using Data_Entity_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Entity_Layer.DatabaseLogic
{
    public class AuthRepo : iAuth
    {

        FinalEntities db;
        public AuthRepo(FinalEntities db)
        {
            this.db = db;
        }
        public token Authenticate(user use)
        {
            token t=null;
            var u=db.users.FirstOrDefault(e => e.email == use.email && e.password == use.password);
            if(u!=null)
            {
                var g = Guid.NewGuid().ToString();
                t = new token()
                {
                    userId = u.id,
                    accessToken = g,
                    createdAt = DateTime.Now
                };
                db.tokens.Add(t);
                db.SaveChanges();
            }
            return t;

        }

        public bool IsAuthenticated(string tok)
        {
           var ac_token= db.tokens.FirstOrDefault(e => e.accessToken.Equals(tok) && e.expiredAt == null);
            if(ac_token!=null)
            {
                return true;
            }
            return false;
        }

        public bool Logout(string tok)
        {
            var t = db.tokens.FirstOrDefault(e =>e.accessToken.Equals(tok));
            if(t!=null)
            {
                t.expiredAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
