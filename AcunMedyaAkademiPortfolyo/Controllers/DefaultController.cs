using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolyo.Models;

namespace AcunMedyaAkademiPortfolyo.Controllers
{
    public class DefaultController : Controller
    {
        DbDominicPortfolioEntities db = new DbDominicPortfolioEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult FeaturePartial()
        {
            var values = db.TblFeature.ToList();
            return PartialView(values);
        }

        public PartialViewResult AboutPartial()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }

        public PartialViewResult ServicePartial()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }

        public PartialViewResult TestimonialPartial()
        {
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }

        public PartialViewResult PortfolioPartial()
        {
            var value = db.TblProject.ToList();
            return PartialView(value);
        }

        public PartialViewResult ContactPartial()
        {
            var value = db.TblContact.ToList();
            return PartialView(value);
        }

        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult JSPartial()
        {
            return PartialView();
        }
    }
}