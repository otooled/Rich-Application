using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RACASem6.Classes;

namespace RACASem6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            using (var db = new TripContext())
            {
                var q1 = from o in db.Trips

                         select o;

                return View(q1);  
            }
            

            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
