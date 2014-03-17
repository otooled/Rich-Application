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

        //Create a leg for a trip
        public ActionResult CreateLeg()
        {
            return View();
        }

        //
        // POST: /test/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLeg([Bind(Include = "LegId,StartLocation, FinishLocation,LegStartDate,LegFinishDate")] Leg leg)
        {
            if (ModelState.IsValid)
            {
                _repo.AddLeg(leg);
                return RedirectToAction("Index");
            }

            return View(leg);
        }

        // GET: /Trip/Create
        public ActionResult CreateTrip()
        {
            return View("CreateTrip");
        }

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
        
        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
