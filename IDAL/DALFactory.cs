using System.Configuration;
using System.Reflection;
using Model;

namespace IDAL
{
    public class DALFactory<T>
    {

        public dynamic CreateDAL()
        {
            if (typeof(T) == typeof(User))
                return Assembly.Load("DAL").CreateInstance("DAL.UserDAL") as IUser;
            else if (typeof(T) == typeof(Article))
                return Assembly.Load("DAL").CreateInstance("DAL.ArticalDAL") as IArticalDAL;
                //else if (typeof(T) == typeof(Nation))
                //    return Assembly.Load(DAL_NameSpace).CreateInstance(DAL_NameSpace + "." + DAL_Nation) as INationIDAL;

                return null;
        }
    }
}
