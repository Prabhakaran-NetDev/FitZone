using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitZone.Models
{
    public partial class Class
    {
        public int ClassID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int DurationMinutes { get; set; }

        public int Capacity { get; set; }

        public int? TrainerID { get; set; }
    }
}
