using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Areas.Admin.Controllers
{
    public class LookupController : Controller
    {
        private TutorialAppContext db = new TutorialAppContext();

        public ActionResult Cities()
        {
            var cities = db.Cities.Select(x => new
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Districts(int cityId)
        {
            var districts = db.Districts
                .Where(x => x.CityId == cityId)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
            return Json(districts, JsonRequestBehavior.AllowGet);
        }
    }
}