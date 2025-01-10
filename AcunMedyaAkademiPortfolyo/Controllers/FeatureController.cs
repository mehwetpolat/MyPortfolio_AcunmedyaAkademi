using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolyo.Models;
namespace AcunMedyaAkademiPortfolyo.Controllers
{
    public class FeatureController : Controller
    {

        DbDominicPortfolioEntities db = new DbDominicPortfolioEntities();

        public ActionResult FeatureList()
        {
            var values = db.TblFeature.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFeature(TblFeature f)
        {
            db.TblFeature.Add(f);
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }

        public ActionResult DeleteFeature(int id)
        {
            var values = db.TblFeature.Find(id);
            db.TblFeature.Remove(values);
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }


        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            // güncellenecek verileri listele
            var value = db.TblFeature.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TblFeature f)
        {
            var value = db.TblFeature.Find(f.FeatureID);
            value.NameSurname = f.NameSurname;
            value.Description = f.Description;
            value.ProjectName = f.ProjectName;
            value.İmageUrl = f.İmageUrl;
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }
    }
}