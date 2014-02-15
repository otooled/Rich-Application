using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RACASem6.Classes
{
    public class Trip
    {
        public int TripId { get; set; }
        public string TripName { get; set; }
        public int NoOfLegs { get; set; }
        public DateTime TripStartDate { get; set; }
        public DateTime TripFinishDate { get; set; }
        public int TripNoOfGuests { get; set; }
    }
}