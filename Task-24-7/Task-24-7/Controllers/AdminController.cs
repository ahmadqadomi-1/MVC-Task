using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_24_7.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult About()
        {

            return View();
        }
        public ActionResult Contact()
        {
            return View("");
        }

        public ActionResult MainHome()
        {

            return View();
        }
        public ActionResult Home()
        {

            return View();
        }
        public ActionResult LogIn(FormCollection form)
        {
            string email = form["username"];
            string password = form["password"];
            if (email != null && password != null)
            {
                return View("LogOut");
            }

            
            return View();
        }

        public ActionResult LogOut()
        {

            return View("MainHome");
        }


        [HttpPost]
        public ActionResult ViewContact(FormCollection form)
        {

            ViewBag.name = form["name"];
            ViewBag.email = form["email"];
            ViewBag.message = form["message"];

            return View("");
        }
    }
}