using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Entity_Layer.Interface
{
   public interface Transaction2
    {
        List<transaction> Tran();
        List<transaction> Pan();
        List<transaction> Vtoa();
        
    }
}
