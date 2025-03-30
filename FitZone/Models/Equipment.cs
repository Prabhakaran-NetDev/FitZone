using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitZone.Models
{
    public partial class Equipment
    {
        public int EquipmentID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public DateTime? MaintenanceDate { get; set; }
    }
}
