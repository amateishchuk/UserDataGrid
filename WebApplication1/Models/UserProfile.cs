using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserProfile
    {

        [ScaffoldColumn(false)]
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [RegularExpression(@"\+\d{12}")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string HomeAddress { get; set; }

        public User User { get; set; }
    }
}