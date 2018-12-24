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
    public class ArticalDAL : BaseDAL, IArticalDAL
    {
        public void Add(Article t)
        {
            throw new NotImplementedException();
        }

        public int AddArticle(Article t)
        {
            StringBuilder sb = new StringBuilder();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("@Title",t.Title),
                new SqlParameter("@Content",t.Content),
                new SqlParameter("@createtime",DateTime.Now),
                new SqlParameter("@FK_Type",t.FK_ArticleType),
                new SqlParameter("@IsValid",true),
            };
            sb.Append("Insert into [Article] (Title,FK_ArticleType,CreateTime,IsValid,[Content]) values (@Title,@FK_Type,@createtime,@IsValid,@Content)");
            int result = SqlHelper.ExecuteNonQuery(sb.ToString(), Params);
            return result;
        }

        public void Delete(Article t)
        {
            throw new NotImplementedException();
        }

        public void Update(Article t)
        {
            throw new NotImplementedException();
        }

        public int Update(List<Article> list)
        {
            throw new NotImplementedException();
        }
    }
}
