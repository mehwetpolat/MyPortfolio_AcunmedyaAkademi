using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolyo.Models;

namespace AcunMedyaAkademiPortfolyo.Controllers
{
    public class StatisticController : Controller
    {
        DbDominicPortfolioEntities db = new DbDominicPortfolioEntities();
        

        public ActionResult Index()
        {
            ViewBag.categorysayisi = db.TblCategory.Count();
            ViewBag.projesayisi = db.TblProject.Count();
            return View();
        }
    }
}