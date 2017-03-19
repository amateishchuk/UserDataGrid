using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}