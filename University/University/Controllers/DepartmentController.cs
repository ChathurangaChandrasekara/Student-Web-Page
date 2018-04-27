using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class DepartmentController : Controller
    {
        UniversityDbContext db = new UniversityDbContext();
        // GET: Department
        [HttpGet]
        public ActionResult DepartmentList()
        {
            List<Department> listdepartmet = new List<Department>();
           

            foreach (var item in db.Departments.ToList())
            {
                Department obj = new Department();

                obj.DepartmentId = item.DepartmentId;
                obj.DepartmentName = item.DepartmentName;
                obj.FacultyId = item.FacultyId;

                Faculty faculty = new Faculty();
                faculty.FacultyId = item.FacultyId;

                faculty.FacultyName = db.Facultys.Where(x => x.FacultyId == item.FacultyId).Select(x => x.FacultyName).FirstOrDefault();

                obj.Faculty = faculty;

                listdepartmet.Add(obj);
            }
            
            return View(listdepartmet);
        }

        [HttpPost]
        public ActionResult DepartmentList(Department model)
        {
          
            if(model.DepartmentName == "")
            {
                return View(db.Departments.ToList());
            }
           

            return View(db.Departments.Where(x => x.DepartmentName.Contains(model.DepartmentName)).ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Facultys = new SelectList(db.Facultys, "FacultyId", "FacultyName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department model)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction("DepartmentList", "Department");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Departments.Where(x=> x.DepartmentId == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(Department model)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department();
                department = db.Departments.Where(x => x.DepartmentId == model.DepartmentId).FirstOrDefault();
                    department.DepartmentName = model.DepartmentName;
                    department.FacultyId = model.FacultyId;
                    db.Entry(department).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("DepartmentList", "Department");
                
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(db.Departments.Where(x=> x.DepartmentId== id).FirstOrDefault());
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Deleteobj(int id)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department();
                department = db.Departments.Where(x => x.DepartmentId == id).FirstOrDefault();

                db.Entry(department).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

                return RedirectToAction("DepartmentList","Department");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(db.Departments.Where(x => x.DepartmentId == id).FirstOrDefault()); 
        }
    }
}