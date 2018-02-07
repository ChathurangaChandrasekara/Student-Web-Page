using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class FacultyController : Controller
    {
        UniversityDbContext db = new UniversityDbContext();

        [HttpGet]
        // GET: Faculty
        public ActionResult FacultyList()
        {
            List<Faculty> list = db.Facultys.ToList();
            return View(list);
        }

        [HttpPost]
        public ActionResult FacultyList(string SearchFaculty)
        {
            List<Faculty> checklist = new List<Faculty>();
            if (SearchFaculty == "")
            {
                checklist = db.Facultys.ToList();
                
            }
            else
            {
                checklist = db.Facultys.Where(x => x.FacultyName.Contains(SearchFaculty)).ToList();
            }
            return View(checklist);
        }


        [HttpGet]
        public ActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Create(Faculty model)
        {
            db.Facultys.Add(model);
            db.SaveChanges();
            return RedirectToAction("FacultyList","Faculty");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
           return View(db.Facultys.Where(x=> x.FacultyId== id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(Faculty model)
        {
            Faculty editfaculty = new Faculty();
            editfaculty = db.Facultys.Where(x => x.FacultyId == model.FacultyId).FirstOrDefault();

            editfaculty.FacultyName = model.FacultyName;
            
            db.SaveChanges();

            return RedirectToAction("FacultyList");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Faculty deletefaculty = new Faculty();
            deletefaculty = db.Facultys.Where(x => x.FacultyId == id).FirstOrDefault();

            
            return View(deletefaculty);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Deleteobj(int id)
        {
            if (ModelState.IsValid)
            {
                Faculty deletefaculty = new Faculty();
                deletefaculty = db.Facultys.Where(x => x.FacultyId == id).FirstOrDefault();

                db.Entry(deletefaculty).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("FacultyList");
            }
            return View();

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Faculty facultydetails = new Faculty();
            facultydetails = db.Facultys.Where(x => x.FacultyId == id).FirstOrDefault();

            return View(facultydetails);
        }



    }
}