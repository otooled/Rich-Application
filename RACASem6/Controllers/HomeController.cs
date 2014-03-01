using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using RACASem6.Classes;
using RACASem6.DAL;
using RACASem6.Models;

namespace RACASem6.Controllers
{
    public class HomeController : Controller
    {
        private ITourRepository _repo;

        public HomeController(ITourRepository repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            return View(_repo.GetAllTrips());



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

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
