using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitZone.Models
{
    public partial class Schedule
    {
        public int ScheduleID { get; set; }

        public int? ClassID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Location { get; set; }
    }
}
