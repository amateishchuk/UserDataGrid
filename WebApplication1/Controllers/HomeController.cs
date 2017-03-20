using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using AutoMapper;
using PagedList.Mvc;
using PagedList;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        IRepository<UserProfile> repo;
        public HomeController(IRepository<UserProfile> r)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserProfile, IndexUserViewModel>()
                  .ForMember(cuvm => cuvm.Login, conf => conf.MapFrom(u => u.User.Login));


                cfg.CreateMap<UserProfile, CreateUserViewModel>()
                  .ForMember(dto => dto.Login, conf => conf.MapFrom(ol => ol.User.Login));
                cfg.CreateMap<CreateUserViewModel, UserProfile>()
                  .ForMember(ol => ol.User, conf => conf.MapFrom(dto => dto));
                cfg.CreateMap<CreateUserViewModel, User>()
                  .ForMember(i => i.Login, conf => conf.MapFrom(dto => dto.Login));


                cfg.CreateMap<UserProfile, EditUserViewModel>()
                  .ForMember(dto => dto.Id, conf => conf.MapFrom(ol => ol.User.Id));
                cfg.CreateMap<EditUserViewModel, UserProfile>()
                  .ForMember(ol => ol.User, conf => conf.MapFrom(dto => dto));
                cfg.CreateMap<EditUserViewModel, User>()
                  .ForMember(i => i.Id, conf => conf.MapFrom(dto => dto.Id));
            });

            repo = r;

            #region Insert
            //repo.Add(new UserProfile { FirstName = "Andrii", LastName = "Mateishchuk", PhoneNumber = "+380937879947", EmailAddress = "amateishchuk@gmail.com", HomeAddress = "Ivana Puliuia, Street 9", User = new User { Login = "zenteyro" } });
            //repo.Add(new UserProfile { FirstName = "Bogdan", LastName = "Mateishchuk", PhoneNumber = "+380937878847", EmailAddress = "bmateishchuk@gmail.com", HomeAddress = "Ivana Puliuia, Street 9", User = new User { Login = "bogdan" } });
            //repo.Add(new UserProfile { FirstName = "Ruslan", LastName = "Mateishchuk", PhoneNumber = "+380937877747", EmailAddress = "rmateishchuk@gmail.com", HomeAddress = "Ivana Puliuia, Street 9", User = new User { Login = "ruslan" } });
            //repo.Add(new UserProfile { FirstName = "Pavlo", LastName = "Mateishchuk", PhoneNumber = "+380937876647", EmailAddress = "pmateishchuk@gmail.com", HomeAddress = "Ivana Puliuia, Street 9", User = new User { Login = "pavlo" } });
            #endregion
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;
            page = page < 1 ? 1 : page;
            var users = Mapper.Map<IEnumerable<UserProfile>, List<IndexUserViewModel>>(repo.GetAllUsers());
            return View(users.ToPagedList(page, pageSize));
        }
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserProfile user = Mapper.Map<CreateUserViewModel, UserProfile>(model);
                repo.Add(user);
                
                return PartialView("Success", "The user was successfully registered");
            }
            return PartialView("Create", model);
        }
        [HttpPost]
        public ActionResult Success(string message)
        {

            return PartialView(message);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            // Настройка AutoMapper
            // Выполняем сопоставление
            EditUserViewModel user = Mapper.Map<UserProfile, EditUserViewModel>(repo.GetUserById(id.Value));
            if (user == null) return PartialView("Success", "Server error. User is apsend in database");
            return PartialView(user);
            
        }
        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Выполняем сопоставление
                UserProfile user = Mapper.Map<EditUserViewModel, UserProfile>(model);
                repo.Edit(user);
                return PartialView("Success", "The user information was successfully updated");
            }
            return PartialView("Edit", model);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();
            IndexUserViewModel user = Mapper.Map<UserProfile, IndexUserViewModel>(repo.GetUserById(id.Value));
            if (user == null) return PartialView("Success", "Server error. User is apsend in database");
            return PartialView(user);
        }
        [HttpPost]
        public ActionResult Delete(IndexUserViewModel model)
        {
            UserProfile user = repo.GetUserById(model.Id);
            repo.Delete(user);
            return PartialView("Success", "The user was successfully deleted from database");
        }


        [HttpGet]
        public JsonResult IsAvailableLogin(string login)
        {
            var result = !(login == "amateishchuk");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
