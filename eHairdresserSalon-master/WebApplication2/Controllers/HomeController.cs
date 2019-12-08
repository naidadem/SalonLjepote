using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        bool isLogin = true;

        public ActionResult Index()
        {
            Login();
            return View();
        }

        public ActionResult Login()
        {
            if (isLogin)
            {
                return RedirectToAction(actionName: "Index");
            }

            return View();
        }
    }
}