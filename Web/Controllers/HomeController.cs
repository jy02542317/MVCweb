using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["LoginSuccess"] = this.TempData["LoginSuccess"];
            return View();
        }

        public ActionResult Login()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            User user = new User();
            user.Username = username;
            user.Password = password;
            UserBLL bo = new UserBLL();
            if (bo.Login(user))
            {
                return RedirectToAction("WriteArticle", "Article");
            }
            else
            {
                this.TempData["LoginSuccess"] = "登陆失败!";        
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult MainIndex()
        {
            return View();
        }

    }
}