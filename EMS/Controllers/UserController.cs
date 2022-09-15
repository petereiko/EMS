using EMS.DatabaseEntities;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Controllers
{
    public class UserController : Controller
    {
        DataModel db = new DataModel();
        public ActionResult Users()
        {
            var users = db.Users.OrderByDescending(x=>x.Id).ToList();
            return View(users);
        }
        public ActionResult Create() 
        {
            UserViewModel model = new UserViewModel();
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

            EMS.DatabaseEntities.User user = new DatabaseEntities.User
            {
                Email = model.Email,
                Password = model.Password,
                IsActive = true,
                Phone = model.PhoneNumber,
                Username = model.Username
            };
            

            //db.Users.Add(user);
            //db.SaveChanges();

            //            @username varchar(50),
            //@password varchar(50),
            //@email varchar(50),
            //@phone varchar(20)

            SqlParameter[] parameters =
            {
                new SqlParameter("@username",model.Username),
                new SqlParameter("@password",model.Password),
                new SqlParameter("@email",model.Email),
                new SqlParameter("@phone",model.PhoneNumber)
            };

            List<MessageResponse> result = db.Database.SqlQuery<MessageResponse>("InsertUser @username, @password, @email, @phone", parameters).ToList();

            MessageResponse response = result.FirstOrDefault();
            if (response.status)
            {
                return RedirectToAction("Users");
            }
            model.Errors.Add(response.message);
            return View(model);
        }
    }
}