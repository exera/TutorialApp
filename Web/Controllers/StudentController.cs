using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        private TutorialAppContext db = new TutorialAppContext();

        // GET: Student
        public ActionResult Index()
        {
            var results = db.Students.ToList();

            return View(results);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (student.Age == 25)
            {
                ModelState.AddModelError("Age", "25 olmaz arkadaş.");
            }

            if (!ModelState.IsValid)
            {
                return View(student);
            }

            db.Students.Add(student);
            db.SaveChanges();

            if (Request.IsAjaxRequest())
            {
                return Json("/student");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var student = db.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Update(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            // ChangeTracking bakalım
            // bu satır zorunlu
            // yoksa DbContext kaydı güncellemez.
            db.Entry(student).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();

            return View(student);
        }

        [HttpGet]
        public ActionResult DeleteConfirm(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            db.Students.Remove(student);
            //db.Entry(student).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("index");
        }
    }
}