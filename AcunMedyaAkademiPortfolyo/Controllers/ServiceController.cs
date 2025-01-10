using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolyo.Models;

namespace AcunMedyaAkademiPortfolyo.Controllers
{
 
    public class ServiceController : Controller
    {
        DbDominicPortfolioEntities db = new DbDominicPortfolioEntities();
        // GET: Service
        public ActionResult ServiceList()
        {
            var values = db.TblService.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(TblService s)
        {
            db.TblService.Add(s);
            db.SaveChanges();
            return RedirectToAction("ServiceList");

        }

        public ActionResult DeleteService(int id)
        {
            var values = db.TblService.Find(id);
            db.TblService.Remove(values);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }


        // güncelleme aşaması
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            // güncellenecek verileri listele
            var value = db.TblService.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(TblService p)
        {
            var value = db.TblService.Find(p.ServiceID);
            value.Title = p.Title;
            value.Description = p.Description;
            value.İmageUrl = p.İmageUrl;
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }
    }
}