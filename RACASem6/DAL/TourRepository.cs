using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RACASem6.Models;
using RACASem6.DAL;

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

        public IQueryable<RACASem6.Models.Leg> GetAllLegs()
        {
            var lq = _ctx.Legs.OrderBy(l => l.StartLocation);
            return lq;
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}