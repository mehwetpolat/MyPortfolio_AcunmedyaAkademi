using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolyo.Models;

namespace AcunMedyaAkademiPortfolyo.Controllers
{
    public class TestimonialController : Controller
    {
        DbDominicPortfolioEntities db = new DbDominicPortfolioEntities();


        public ActionResult TestimonialList()
        {
            var values = db.TblTestimonial.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(TblTestimonial t)
        {
            db.TblTestimonial.Add(t);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var values = db.TblTestimonial.Find(id);
            db.TblTestimonial.Remove(values);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }


        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.TblTestimonial.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial t)
        {
            var values = db.TblTestimonial.Find(t.TestimonialID);


            values.Title = t.Title;
            values.Description = t.Description;
            values.NameSurname = t.NameSurname;
            values.ImageUrl = t.ImageUrl;
            values.Job = t.Job;
            values.Status = t.Status;
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}