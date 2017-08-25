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
            db.Students.Add(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}