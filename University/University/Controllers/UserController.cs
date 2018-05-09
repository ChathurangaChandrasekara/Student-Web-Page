using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class UserController : Controller
    {
        UniversityDbContext db = new UniversityDbContext();

        [HttpGet]
        public ActionResult UserList()
        {
            User UserAccess = new User();
            if (UserAccess.Type == "Admin")
            { 

                List<User> listuser = new List<User>();

                foreach (var item in db.Users.ToList())
                {
                    User obj = new User();
                    obj.FirstName = item.FirstName;
                    obj.LastName = item.LastName;
                    obj.PhoneNumber = item.PhoneNumber;
                    obj.UniversityCard = item.UniversityCard;
                    obj.UserId = item.UserId;
                    obj.UserName = item.UserName;
                    obj.UserPassword = item.UserPassword;
                    obj.FacultyId = item.FacultyId;
                    obj.FirstName = item.FirstName;
                    obj.EPNumber = item.EPNumber;
                    obj.Email = item.Email;
                    obj.DepartmentId = item.DepartmentId;
                    obj.BatchId = item.BatchId;
                    obj.Address = item.Address;

                    Faculty faculty = new Faculty();
                    faculty.FacultyId = item.FacultyId;

                    faculty.FacultyName = db.Facultys.Where(x => x.FacultyId == item.FacultyId).Select(x => x.FacultyName).FirstOrDefault();

                    obj.Faculty = faculty;

                    Department department = new Department();
                    department.DepartmentId = item.DepartmentId;

                    department.DepartmentName = db.Departments.Where(x => x.DepartmentId == item.FacultyId).Select(x => x.DepartmentName).FirstOrDefault();

                    obj.Department = department;


                    Batch batch = new Batch();
                    batch.BatchId = item.BatchId;

                    batch.BatchName = db.Batchs.Where(x => x.BatchId == item.BatchId).Select(x => x.BatchName).FirstOrDefault();

                    obj.Batch = batch;


                    listuser.Add(obj);

                }
                return View(listuser);
            }
            return View();
        }


        [HttpPost]
        public ActionResult UserList(User model)
        {

            if (model.FirstName == "")
            {
                return RedirectToAction("UserList");
            }
            else
            {
                User UserAccess = new User();
                if (UserAccess.Type == "Admin")
                {
                    return View(db.Users.Where(x => x.UserName.Contains(model.UserName)).ToList());
                }


                return View(db.Users.Where(x => x.UserName== model.UserName).Single());
            }
        }

        

        [HttpGet]
        public ActionResult Create()
        {
            
            ViewBag.Facultys = new SelectList(db.Facultys, "FacultyId", "FacultyName");
            ViewBag.Departments = new SelectList(db.Departments , "DepartmentId", "DepartmentName");
            ViewBag.Batchs = new SelectList(db.Batchs, "BatchId", "BatchName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(User model)
        {
            

            if (ModelState.IsValid)
            {
                db.Users.Add(model);
                db.SaveChanges();

                User UserAccess = new User();
                if (UserAccess.Type == "Admin")
                {
                    return RedirectToAction("UserList","User");
                }
                else
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Facultys = new SelectList(db.Facultys, "FacultyId", "FacultyName");
            ViewBag.Departments = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            ViewBag.Batchs = new SelectList(db.Batchs, "BatchId", "BatchName");


            return View(db.Users.Where(x => x.UserId == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {

            User UserAccess = new User();
            if (UserAccess.Type == "Admin")
            {


                if (ModelState.IsValid)
                {
                    User user = new User();

                    user = db.Users.Where(x => x.UserId == model.UserId).FirstOrDefault();

                    user.Address = model.Address;
                    user.BatchId = model.BatchId;
                    user.BatchName = model.BatchName;
                    user.DepartmentId = model.DepartmentId;
                    user.DepartmentName = model.DepartmentName;
                    user.Email = model.Email;
                    user.EPNumber = model.EPNumber;
                    user.FacultyId = model.FacultyId;
                    user.FacultyName = model.FacultyName;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.PhoneNumber = model.PhoneNumber;
                    user.UniversityCard = model.UniversityCard;
                    user.UserId = model.UserId;
                    user.UserName = model.UserName;
                    user.UserPassword = model.UserPassword;

                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("UserList", "User");

                }
            }
            return View();
        }

        [HttpGet]
       public ActionResult Delete(int id)
        {

            return View(db.Users.Where(x => x.UserId == id).FirstOrDefault());

        }

       [HttpPost]
       [ActionName("Delete")]
       public ActionResult Deleteobj(int id)
        {
            User UserAccess = new User();
            if (UserAccess.Type=="Admin")
            {


                if (ModelState.IsValid)
                {
                    User user = new Models.User();
                    user = db.Users.Where(x => x.UserId == id).FirstOrDefault();

                    db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();

                    return RedirectToAction("UserList", "User");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            User user = new User();
            user = db.Users.Where(x => x.UserId == id).FirstOrDefault();

            Batch batch = new Batch();
            batch = db.Batchs.Where(x => x.BatchId == user.BatchId).FirstOrDefault();
            user.BatchName = batch.BatchName;

            Department department = new Department();
            department = db.Departments.Where(x => x.DepartmentId == user.DepartmentId).FirstOrDefault();
            user.DepartmentName = department.DepartmentName;

            Faculty faculty = new Faculty();
            faculty = db.Facultys.Where(x => x.FacultyId == user.FacultyId).FirstOrDefault();
            user.FacultyName = faculty.FacultyName;


            return View(user);
        }


    }
}