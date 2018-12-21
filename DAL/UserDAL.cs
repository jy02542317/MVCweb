using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace DAL
{
    public class UserDAL : BaseDAL, IUser
    {
        public void Add(User t)
        {
            StringBuilder sb = new StringBuilder();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("@username",t.Username),
                new SqlParameter("@password",t.Password),
                new SqlParameter("@createtime",DateTime.Now),
                new SqlParameter("@IsValid",true),
                new SqlParameter("@Level",1)
            };
            sb.Append("Insert into [User] (username,password,createtime,NowPass,IsValid,[Level]) values (@username,@password,@createtime,@password,@IsValid,@Level)");
            SqlHelper.ExecuteNonQuery(sb.ToString(), Params);
        }

        public void Delete(User t)
        {
            throw new NotImplementedException();
        }

        public List<User> getListByCondition(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User t)
        {
            throw new NotImplementedException();
        }

        public int Update(List<User> list)
        {
            throw new NotImplementedException();
        }

        public int AddUser(User user)
        {
            StringBuilder sb = new StringBuilder();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("@username",user.Username),
                new SqlParameter("@password",user.Password),
                new SqlParameter("@createtime",DateTime.Now),
                new SqlParameter("@IsValid",true),
                new SqlParameter("@Level",user.Level)
            };
            sb.Append("Insert into [User] (username,password,createtime,NowPass,IsValid,[Level]) values (@username,@password,@createtime,@password,@IsValid,@Level)");
            int result = SqlHelper.ExecuteNonQuery(sb.ToString(), Params);
            return result;
        }

        public int ChangePassword(string password, int id)
        {
            StringBuilder sb = new StringBuilder();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("@password",password),
                new SqlParameter("@modifytime",DateTime.Now),
                new SqlParameter("@Id",id)
            };
            sb.Append("Update [User] set Password=@password,ModifyTime=@modifytime where Id=@Id)");
            int result = SqlHelper.ExecuteNonQuery(sb.ToString(), Params);
            return result;
        }

        public bool Login(User user)
        {
            StringBuilder sb = new StringBuilder();

            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("@password",user.Password),
                new SqlParameter("@username",user.Username)
            };

            sb.Append("select count(*) from [User] where username=@username and password=@password and isvalid=1");

            object o = SqlHelper.ExecuteScalar(sb.ToString(), Params);
            string str = o == null ? "0" : o.ToString();
            if (int.TryParse(str, out int amount))
                return amount > 0 ? true : false;
            else
                return false;
        }

        public bool ExistName(string username)
        {
            StringBuilder sb = new StringBuilder();

            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("@username",username)
            };

            sb.Append("select count(*) from [User] where username=@username and isvalid=1");

            object o = SqlHelper.ExecuteScalar(sb.ToString(), Params);
            string str = o == null ? "0" : o.ToString();
            if (int.TryParse(str, out int amount))
                return amount > 0 ? true : false;
            else
                return false;
        }
    }
}
