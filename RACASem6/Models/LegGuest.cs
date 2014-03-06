using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RACASem6.Models
{
    public class LegGuest
    {
        public int LegGuestID { get; set; }
       
        public int GuestId { get; set; }
        
        public int LegId { get; set; }

        public virtual Leg Leg { get; set; }
        public virtual Guest Guest { get; set; }
    }
}