using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitZone.Models
{
    public partial class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public long? Phone { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(30)]
        public string pass { get; set; }
    }
    public partial class UserDTO
    {
        [Required]
        public int OTP { get; set; }

        [StringLength(50)]
        public string OldPassword { get; set; }

        [StringLength(100)]
        public string ConfirmPassword { get; set; }
    }
    public class CombinedUser
    {
        public User Users { get; set; }
        public UserDTO UserDTOs { get; set; }
    }
}
