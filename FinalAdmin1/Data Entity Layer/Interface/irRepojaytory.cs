using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Entity_Layer.Interface
{
   public  interface irRepojaytory<T,ID>
    {
        List<T> Get();
        T Get(ID id);
        void Add(T e);
        void Edit(T e);
        void Delete(ID id);

    }
}
