using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_23_7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {      
            return View();
        }

        [HttpPost]
        public ActionResult ViewContact(FormCollection form)
        {
            ViewBag.name = form["name"];
            ViewBag.num = form["num"];
            ViewBag.gender = form["gender"];
            ViewBag.Cont = form["Cont"];
            ViewBag.inter = form["inter"];
            return View();
        }
    }
}