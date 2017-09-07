using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class NewsController : Controller
    {
        private TutorialAppContext db = new TutorialAppContext();

        public ActionResult Index()
        {
            var vm = db.News.ToList();

            return View(vm);
        }
    }
}