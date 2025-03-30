using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitZone.Models
{
    public partial class Membership
    {
        public int MembershipID { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int DurationDays { get; set; }
    }
}
