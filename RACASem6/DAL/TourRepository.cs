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
            return _ctx.Trips.OrderBy(t => t.TripName);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}