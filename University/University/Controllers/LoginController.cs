using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class LoginController : Controller
    {
        UniversityDbContext db = new UniversityDbContext();
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Where(x => x.UserName == model.UserName && x.UserPassword == model.UserPassword).Any())
                {
                    User user = db.Users.Where(x => x.UserName == model.UserName && x.UserPassword == model.UserPassword).FirstOrDefault();
                    if (user.Type=="Admin")
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("UserIndex", "User");
                    }
                   
                }
                else
                {
                    ViewBag.error = "error";
                }
               
            }
            return View();
        }


    }
}