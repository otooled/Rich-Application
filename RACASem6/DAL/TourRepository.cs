using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RACASem6.Models;
using RACASem6.DAL;
using System.Data.Entity;

namespace RACASem6.DAL
{
    public class TourRepository:ITourRepository
    {
        private TourContext _ctx;

        public TourRepository()
        {
            _ctx = new TourContext();
        }

        public IQueryable<RACASem6.Models.Trip> GetAllTrips()
        {
            var q = _ctx.Trips.OrderBy(t => t.TripName);
            return q;
        }

        public RACASem6.Models.Trip GetTripById(int? id)
        {
            return _ctx.Trips.SingleOrDefault(t => t.TripId == id);
        }

        public Trip GetLegsByTripId(int? id)
        {
            Trip t = _ctx.Trips.Find(id);
            

            return t;
            //return _ctx.Legs.Where(l => l.Trip.TripId == id);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}