using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WriteArticle()
        {
            return View();
        }

        public ActionResult CreateArticle(string Title, string MainContent,string fk_type)
        {
            Article art = new Article();
            art.Content = MainContent;
            art.CreateTime = DateTime.Now;
            art.Title = Title;
            art.IsValid = true;
            art.FK_ArticleType = int.Parse(fk_type);
            ArticleBLL bll = new ArticleBLL();
            bll.AddArticle(art);
            return Json("保存成功");
        }

        public ActionResult Picture(string imageData, string name, string type)
        {
            string url = Base64StringToImage(imageData, name, type);
            returnUrl returnurl = new returnUrl();
            returnurl.url = url;
            var res = JsonConvert.SerializeObject(returnurl);
            return Json(res);
        }

        protected string Base64StringToImage(string strbase64, string name, string type)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(strbase64);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                string bmpname = DateTime.Now.ToFileTime() + "_" + name;
                string path = System.AppDomain.CurrentDomain.BaseDirectory;
                string savepath = path + "\\Image\\Article\\" + bmpname;
                switch (type)
                {
                    case "image/jpeg":
                        bmp.Save(savepath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "image/png":
                        bmp.Save(savepath, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case "image/gif":
                        bmp.Save(savepath, System.Drawing.Imaging.ImageFormat.Gif);
                        break;

                }
                ms.Close();
                string url = "/Image/Article/" + bmpname;
                return url;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

    }
    public class returnUrl
    {
        public string url { get; set; }
    }
}