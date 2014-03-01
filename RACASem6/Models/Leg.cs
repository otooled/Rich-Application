using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RACASem6.Models
{
    public class Leg
    {
        public int LegId { get; set; }
        public string StartLocation { get; set; }
        public string FinishLocation { get; set; }
        public DateTime LegStartDate { get; set; }
        public DateTime LegFinishDate { get; set; }

        //navigation fields
        public virtual Trip Trip { get; set; }
        public virtual ICollection<LegGuest> LegGuests { get; set; } 
    }
}