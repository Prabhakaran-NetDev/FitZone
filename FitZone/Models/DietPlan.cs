using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitZone.Models
{
    public partial class DietPlan
    {
        public int DietPlanID { get; set; }

        public int? UserID { get; set; }

        public int? TrainerID { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
