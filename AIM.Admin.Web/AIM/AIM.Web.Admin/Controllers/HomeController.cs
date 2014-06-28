using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIM.Web.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A.I.M. Admin...";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "5 Programmers of Tomorrow...";

            return View();
        }
    }
}