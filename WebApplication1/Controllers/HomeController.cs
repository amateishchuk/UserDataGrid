using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using Ninject;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        IRepository repo;
        public HomeController(IRepository r)
        {
            repo = r;
        }
        public ActionResult Index()
        {
            repo.Insert(new User { Login = "zenteyro", UserProfile = new UserProfile { FirstName = "Andrii", LastName = "Mateishchuk", PhoneNumber = "+380937879947", EmailAddress = "amateishchuk@gmail.com", HomeAddress = "Ivana Puliuia, Street 9" } });
            repo.Insert(new User { Login = "bogdan", UserProfile = new UserProfile { FirstName = "Bogdan", LastName = "Mateishchuk", PhoneNumber = "+380937878847", EmailAddress = "bmateishchuk@gmail.com", HomeAddress = "Ivana Puliuia, Street 9" } });
            repo.Insert(new User { Login = "ruslan", UserProfile = new UserProfile { FirstName = "Ruslan", LastName = "Mateishchuk", PhoneNumber = "+380937877747", EmailAddress = "rmateishchuk@gmail.com", HomeAddress = "Ivana Puliuia, Street 9" } });
            repo.Insert(new User { Login = "pavlo", UserProfile = new UserProfile { FirstName = "Pavlo", LastName = "Mateishchuk", PhoneNumber = "+380937876647", EmailAddress = "pmateishchuk@gmail.com", HomeAddress = "Ivana Puliuia, Street 9" } });

            return View(repo.GetAllUsers());
        }
    }
}
