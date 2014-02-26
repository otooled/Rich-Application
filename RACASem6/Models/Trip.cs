using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RACASem6.Models;


namespace RACASem6.Models
{
    public class Trip
    {
       
        public int TripId { get; set; }

        [Display(Name = "Trip Name" )]
        public string TripName { get; set; }

        [Display(Name = "No. of legs")]
        public int NoOfLegs { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}"), Display(Name = "Start date")]
        public DateTime TripStartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}"), Display(Name = "Finish date")]
        public DateTime TripFinishDate { get; set; }

        [Display(Name = "No. of guests")]
        public int TripNoOfGuests { get; set; }

        public virtual List<Leg> Legs { get; set; } 
    }
}

//DAVID-PC\SQLEXPRESS