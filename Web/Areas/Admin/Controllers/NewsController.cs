using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private TutorialAppContext db = new TutorialAppContext();

        // GET: Admin/News
        public ActionResult Index()
        {
            return View(db.News.ToList());
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,ImageId,Image,Date,Tags,Category,Slug")] News news, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var ext = Path.GetExtension(file.FileName);
                var mime = MimeMapping.GetMimeMapping(ext);
                if (!mime.StartsWith("image/"))
                {
                    ModelState.AddModelError("Image", "Resim yüklemelisiniz.");
                }
                else
                {
                    var fileName = Path.GetRandomFileName().Replace(".", "") + ext;
                    var clientPath = "/contents/images/" + fileName;
                    var virtualPath = "~" + clientPath;
                    var filePath = Server.MapPath(virtualPath); // maps virtual directory to real filesystem
                    file.SaveAs(filePath);

                    var img = new Image();
                    img.Url = clientPath;
                    img.Alt = "";
                    news.Image = img; // associate img with news record
                }
            }
            else
            {
                ModelState.AddModelError("Image", "Resim yüklemelisiniz.");
            }

            if (ModelState.IsValid)
            {
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: Admin/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,ImageId,Image,Date,Tags,Category,Slug")] News news, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var ext = Path.GetExtension(file.FileName);
                var mime = MimeMapping.GetMimeMapping(ext);
                if (!mime.StartsWith("image/"))
                {
                    ModelState.AddModelError("Image", "Resim yüklemelisiniz.");
                }
                else
                {
                    var fileName = Path.GetRandomFileName().Replace(".", "") + ext;
                    var clientPath = "/contents/images/" + fileName;
                    var virtualPath = "~" + clientPath;
                    var filePath = Server.MapPath(virtualPath); // maps virtual directory to real filesystem
                    file.SaveAs(filePath);

                    if (news.ImageId > 0)
                    {
                        var img = db.Images.Find(news.ImageId);
                        img.Url = clientPath;
                    }
                    else
                    {
                        var img = new Image();
                        img.Url = clientPath;
                        img.Alt = "";
                        news.Image = img; // associate img with news record 
                    }

                    // ALTERNATIVE: Creates new image record
                    //var img = new Image();
                    //img.Url = clientPath;
                    //img.Alt = "";
                    //news.Image = img; // associate img with news record
                }
            }

            if (ModelState.IsValid)
            {
                // uncomment to save update Title field only
                //var persistedNews = db.News.Find(news.Id);
                //UpdateModel(persistedNews, new string[] { "Title" });
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: Admin/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
