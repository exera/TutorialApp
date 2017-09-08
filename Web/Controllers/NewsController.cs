using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using X.PagedList;

namespace Web.Controllers
{
    public class NewsController : Controller
    {
        private TutorialAppContext db = new TutorialAppContext();

        public ActionResult Index(int? page)
        {
            var query = db.News.AsQueryable();
            var pageNumber = page ?? 1;

            var onePageOfNews = query.OrderByDescending(x => x.Date).ToPagedList(pageNumber, 1);

            return View(onePageOfNews);
        }

        public ActionResult Detail(int id)
        {
            var news = db.News.FirstOrDefault(x => x.Id == id);
            if(news == null)
            {
                return HttpNotFound();
            }

            return View(news);
        }
    }
}