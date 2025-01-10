
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiPortfolyo.Models;

namespace AcunMedyaAkademiPortfolyo.Controllers
{
    public class ContactController : Controller
    {
        DbDominicPortfolioEntities db = new DbDominicPortfolioEntities();

        [HttpGet]
        public ActionResult ContactList()
        {
            var values = db.TblContact.ToList();
            return View(values);
        }

        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(TblContact c)
        {
                c.SendDate = DateTime.Now;
                c.IsRead = false;
                db.TblContact.Add(c);
                db.SaveChanges();
                return Redirect("/Default/Index#contact");
        }

        public ActionResult OpenContact(int id)
        {
            var value = db.TblContact.Find(id);
            return View(value);
        }
    }
}
