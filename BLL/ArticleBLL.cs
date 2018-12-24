using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace BLL
{
    public class ArticleBLL
    {
        private static IArticalDAL artical = new DALFactory<Article>().CreateDAL();

        public string AddArticle(Article t)
        {

            try
            {
                int r = artical.AddArticle(t);
                return "保存成功！";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
