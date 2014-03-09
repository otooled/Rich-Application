using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Leg tripLegs = _repo.GetLegsByTripId(id);
            if (tripLegs == null)
            {
                return HttpNotFound();
            }
            return View(tripLegs);
        }

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /test/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Trip trip)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _repo.Trips.Add(trip);
        //        _repo.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(trip);
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your app description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
