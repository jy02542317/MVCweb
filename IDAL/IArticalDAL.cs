using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IArticalDAL: IBaseDAL<Article>
    {
        int AddArticle(Article t);
    }
}
