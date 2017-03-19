using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class CompanyInput
    {
        [Required]
        public string CompanyName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        [Remote("IsNumberEven", "Home", ErrorMessage = "The number is odd.")]
        public int EvenNumber { get; set; }
    }
}