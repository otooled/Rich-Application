using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RACASem6.Models;
using RACASem6.DAL;
using System.Data.Entity;


namespace RACASem6.DAL
{
    public class TourRepository : ITourRepository
    {
        private TourContext _ctx;

        public TourRepository()
        {
            _ctx = new TourContext();
        }

        //List all trips
        public IQueryable<RACASem6.Models.Trip> GetAllTrips()
        {
            var q = _ctx.Trips.OrderBy(t => t.TripName);
            return q;
        }

        //List all trips by trip id
        public RACASem6.Models.Trip GetTripById(int? id)
        {
            return _ctx.Trips.SingleOrDefault(t => t.TripId == id);
        }

        //List legs by trip id
        public Trip GetLegsByTripId(int? id)
        {
            Trip t = _ctx.Trips.Find(id);
            return t;
        }

        //Add trip to database
        public RACASem6.Models.Trip AddTrip(Trip t)
        {
            _ctx.Entry(t).State = EntityState.Added;
            _ctx.SaveChanges();
            return t;
        }

        //Add leg to trip
        public RACASem6.Models.Leg AddLeg(Leg l)
        {
            _ctx.Entry(l).State = EntityState.Added;
            _ctx.SaveChanges();
            return l;
        }

        //List all guests by first name
        public IQueryable<RACASem6.Models.Guest> ListGuest()
        {
            var q = _ctx.Guests.OrderBy(g => g.FirstName);
            return q;
        }

        //Add guest to let
        public RACASem6.Models.Guest AddGuest(Guest g)
        {
            _ctx.Entry(g).State = EntityState.Added;
            _ctx.SaveChanges();
            return g;
        }

        //Check if there are 3 or more guests on a leg
        public IQueryable<RACASem6.Models.Leg> CheckTripViability(int id = 0)
        {
            var tripV = from tv in _ctx.Legs
                        where tv.LegGuests.Count >= 3
                        select tv;
            return tripV;
        }

        //Close db connection
        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}