using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Entity_Layer.Interface
{
    public interface iAuth
    {
        token Authenticate(user use);
        bool IsAuthenticated(string tok);
        bool Logout(string token);
    }
}
