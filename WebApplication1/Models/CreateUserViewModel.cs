using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class CreateUserViewModel
    {
        [Required]
        [Display(Name = "Login:")]
        [RegularExpression(@"\S{3,}")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "First name:")]
        [RegularExpression("[A-Za-z]{3,}")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name:")]
        [RegularExpression("[A-Za-z]{3,}")]
        public string LastName { get; set; }

        [Display(Name = "Phone number:")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(13, MinimumLength = 13)]
        [RegularExpression(@"\+\d{12}")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-mail:")]
        [UIHint("EmailAddress")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string EmailAddress { get; set; }

        [Display(Name = "Home address:")]
        public string HomeAddress { get; set; }
    }
}