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

           Trip trips = _repo.GetTripById(id);
            if (trips == null)
            {
                return HttpNotFound();
            }
            return View(trips);
        }

        public ActionResult LegsAction(int id)
        {
            Trip t = _repo.GetLegsByTripId(id);
            List<Leg> ls = t.Legs;

            return PartialView("_LegsAction", ls);
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

        // GET: /Trip/Create
        public ActionResult CreateTrip()
        {
            return View("CreateTrip");
        }

        // POST: /Trip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTrip([Bind(Include = "TripId,TripName, NoOfLegs,TripStartDate,TripFinishDate,TripNoOfGuests")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTrip(trip);
                
                return RedirectToAction("Index");
            }
            // if not valid, re-send View with already entered data
            return View(trip);
        }

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
