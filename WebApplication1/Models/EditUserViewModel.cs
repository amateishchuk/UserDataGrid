using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class EditUserViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public string Login { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, input your first name")]
        [Display(Name = "First name: *")]
        [RegularExpression(@"[A-Za-z]{3,}", ErrorMessage = "First name must contain letters without spaces, at least 3 characters")]
        public string FirstName { get; set; }



        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, input your last name")]
        [Display(Name = "Last name: *")]
        [RegularExpression(@"[A-Za-z]{3,}", ErrorMessage = "Last name must contain letters without spaces, at least 3 characters")]
        public string LastName { get; set; }



        [Display(Name = "Phone number:")]
        [RegularExpression(@"\+\d{12}", ErrorMessage = "Phone number format must be +123456789012")]
        public string PhoneNumber { get; set; }



        [Display(Name = "E-mail:")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "E-mail format must be mail@test.tt")]
        public string EmailAddress { get; set; }



        [Display(Name = "Home address:")]
        public string HomeAddress { get; set; }
    }
}