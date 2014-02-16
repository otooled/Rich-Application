using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RACASem6.Classes
{
    public class TripDB : DropCreateDatabaseAlways<TripContext>
    {
        protected override void Seed(TripContext db)
        {
            var trip = new Trip
                           {
                               TripId = 1,
                               TripName = "Test",
                               NoOfLegs = 2,
                               TripNoOfGuests = 4
                           };
        }
    }
}