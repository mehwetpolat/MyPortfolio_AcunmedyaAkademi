using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using AcunMedyaAkademiPortfolyo.Models;
using System.Net;

namespace AcunMedyaAkademiPortfolio.Controllers
{


    public class CategoryController : Controller
    {
        DbDominicPortfolioEntities db = new DbDominicPortfolioEntities();

        public ActionResult CategoryList()
        {
            var values = db.TblCategory.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateCategory(TblCategory p)
        {
            db.TblCategory.Add(p);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }



        
        public ActionResult DeleteCategory(int id)
        {
            var values = db.TblCategory.Find(id);
            db.TblCategory.Remove(values);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }



        // güncelleme aşaması
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            // güncellenecek verileri listele
            var value = db.TblCategory.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TblCategory p)
        {
            var value = db.TblCategory.Find(p.CategoryID);
            value.CategoryName = p.CategoryName;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

       

    }
}