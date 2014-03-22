using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RACASem6.Models
{
    public class Guest
    {
        public int GuestId { get; set; }

        [Display(Name = "Guest Name")]
        public string FirstName { get; set; }

        public virtual ICollection<LegGuest> LegGuests { get; set; } 
    }//end class
}//end namespace