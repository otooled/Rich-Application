using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RACASem6.Models
{
    public class Leg
    {
        public int LegId { get; set; }
        [Display(Name = "Start location")]
        public string StartLocation { get; set; }
        [Display(Name = "Finish location")]
        public string FinishLocation { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}"), Display(Name = "Start date")]
        public DateTime LegStartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}"), Display(Name = "Finish date")]
        public DateTime LegFinishDate { get; set; }

       // public int TripId { get; set; }

        //navigation fields
        public virtual Trip Trip { get; set; }
        public virtual ICollection<LegGuest> LegGuests { get; set; } 
    }
}