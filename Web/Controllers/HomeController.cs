using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var images = new List<Image>{
                new Image {
                    Url = "/contents/images/image_1068.jpg",
                    Alt = "1068"
                },
                new Image {
                    Url = "/contents/images/image_1070.jpg",
                    Alt = "1070"
                },
            };

            Image foundImage = null;
            foreach (var image in images)
            {
                if(image.Alt == "1068")
                {
                    foundImage = image;
                    break;
                }
            }



            return View(images);
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}