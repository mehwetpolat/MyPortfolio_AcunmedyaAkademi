using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolyo.Models;

namespace AcunMedyaAkademiPortfolyo.Controllers
{
    public class ProjectController : Controller
    {

        DbDominicPortfolioEntities db = new DbDominicPortfolioEntities();
        // GET: Project
        public ActionResult ProjectList()
        {
            var values = db.TblProject.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            // dropdownlist categori id sine göre categori adını spinner çekme
            List<SelectListItem> values = (from x in db.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();

        }

        [HttpPost]
        public ActionResult CreateProject(TblProject p)
        {
            db.TblProject.Add(p);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }


        public ActionResult DeleteProject(int id)
        {
            var values = db.TblProject.Find(id);
            db.TblProject.Remove(values);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }



        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            List<SelectListItem> values1 = (from x in db.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values1;


            var value = db.TblProject.Find(id);
            return View(value);


        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject p)
        {
            var value = db.TblProject.Find(p.ProjectID);
            value.ProjectDescription = p.ProjectDescription;
            value.ImageUrl = p.ImageUrl;
            value.CategoryID = p.CategoryID;
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }
    }
}