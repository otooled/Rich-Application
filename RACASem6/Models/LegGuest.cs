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
        [Key, Column(Order = 0)]
        public int LetGuestGuestId { get; set; }
        [Key, Column(Order = 1)]
        public int LegGuestLegId { get; set; }

        public virtual Leg Leg { get; set; }
        public virtual Guest Guest { get; set; }
    }
}