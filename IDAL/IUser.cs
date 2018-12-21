using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IUser : IBaseDAL<User>
    {
        List<User> getListByCondition(User user);

        int AddUser(User user);

        int ChangePassword(string password,int id);

        bool Login(User user);

        bool ExistName(string username);
    }
}
