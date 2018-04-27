using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class BatchController : Controller
    {
        UniversityDbContext db = new UniversityDbContext();
        // GET: Batch
        [HttpGet]
        public ActionResult BatchList()
        {
            List<Batch> listbatch  = new List<Batch>();


            foreach (var item in db.Batchs.ToList())
            {
                Batch obj = new Batch();

                obj.BatchId = item.BatchId;
                obj.BatchName = item.BatchName;
                //obj.DepartmentId = item.DepartmentId;
                //obj.FacultyId = item.FacultyId;

                //Faculty faculty = new Faculty();
                //faculty.FacultyId = item.FacultyId;
                //faculty.FacultyName = db.Facultys.Where(x => x.FacultyId == item.FacultyId).Select(x => x.FacultyName).FirstOrDefault();

                //obj.Faculty = faculty;

                //Department department = new Department();
                //department.DepartmentId = item.DepartmentId;
                //department.DepartmentName = db.Departments.Where(x => x.DepartmentId == item.DepartmentId).Select(x => x.DepartmentName).FirstOrDefault();

                //obj.department = department;

                listbatch.Add(obj);
            }

            return View(listbatch);
           
        }

        [HttpPost]
        public ActionResult BatchList(Batch model)
        {
            if (model.BatchName == "")
            {
                return RedirectToAction("BatchList");
            }

            return View(db.Batchs.Where(x=> x.BatchName.Contains(model.BatchName)).ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            //ViewBag.Facultys = new SelectList(db.Facultys, "FacultyId", "FacultyName");
            //ViewBag.Departments = new SelectList(db.Departments,"DepartmentId","DepartmentName");
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Batch model)
        {
            if (ModelState.IsValid)
            {
                db.Batchs.Add(model);
                db.SaveChanges();
                
            }
            return RedirectToAction("BatchList","Batch");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Batchs.Where(x=> x.BatchId == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(Batch model)
        {
            if(ModelState.IsValid)
            {
                Batch batch = new Batch();
                batch = db.Batchs.Where(x=> x.BatchId == model.BatchId).FirstOrDefault();

                batch.BatchName = model.BatchName;
                //batch.DepartmentId = model.DepartmentId;
                //batch.FacultyId = model.FacultyId;

                db.Entry(batch).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("BatchList", "Batch");

            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(db.Batchs.Where(x => x.BatchId == id).FirstOrDefault());
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Deleteobj(int id)
        {
            if (ModelState.IsValid)
            {
                Batch batch = new Batch();
                batch = db.Batchs.Where(x => x.BatchId == id).FirstOrDefault();

               
                db.Entry(batch).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

                return RedirectToAction("BatchList", "Batch");

            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(db.Batchs.Where(x=> x.BatchId == id).FirstOrDefault());
        }


    }
}