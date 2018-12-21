using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IBaseDAL<T> where T : class
    {
        void Add(T t);
        void Update(T t);
        void Delete(T t);

        int Update(List<T> list);
     

    }
}
