using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolyo.Models;

namespace AcunMedyaAkademiPortfolyo.Controllers
{
    public class AboutController : Controller
    {
        DbDominicPortfolioEntities db = new DbDominicPortfolioEntities();


        
        public ActionResult AboutList()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(TblAbout a)
        {
            db.TblAbout.Add(a);
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }


        public ActionResult DeleteAbout(int id)
        {
            var values = db.TblAbout.Find(id);
            db.TblAbout.Remove(values);
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }



        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            // güncellenecek verileri listele
            var value = db.TblAbout.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout a)
        {
            var value = db.TblAbout.Find(a.AboutID);
            value.Description = a.Description;
            value.Title = a.Title;
            value.ImageUrl = a.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }

        public ActionResult DownloadPDF()
        {
            string filePath = Server.MapPath("~/Content/mehmetpolat_cv.pdf");
            string fileName = "mehmetpolat_cv.pdf";


            return File(filePath, "application/pdf", fileName);
        }
    }
}