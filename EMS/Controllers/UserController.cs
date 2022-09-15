using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Create() 
        {
            UserViewModel model = new UserViewModel();
            model.Id = 1;
            model.Username = "peter";
            model.PhoneNumber = "07068352430";
            model.Password = "Password";
            model.Email = "peter@gmail.com";
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            bool isvalid = ModelState.IsValid;
            if (!isvalid)
            {

                foreach (ModelState item in ModelState.Values)
                {
                    foreach (ModelError error in item.Errors)
                    {
                        model.Errors.Add(error.ErrorMessage);
                    }
                }

                return View(model);
            }
            //Processing...
            return View(model);
        }
    }
}