using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace University.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult UserIndex()
        {
            return View();
        }
    }
}