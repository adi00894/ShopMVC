using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PraktyczneKursy.DAL;

namespace PraktyczneKursy.Controllers
{
    public class KursyController : Controller
    {
         private KursyKontext _db = new KursyKontext();

        // GET: Kursy
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Lista(string nazwaKategori, string searchQuery= null)
        {
            var name = User.Identity.Name;
            //logger.Info("Strona kategoria | " + nazwaKategori + " | " + name);
            var kategoria = _db.Kategorie.Include("Kursy")
                .Where(k => k.NazwaKategorii.ToUpper() == nazwaKategori.ToUpper()).Single();

            var kursy = kategoria.Kursy.Where(a => (searchQuery == null ||
                                              a.TytulKursu.ToLower().Contains(searchQuery.ToLower()) ||
                                              a.AutorKursu.ToLower().Contains(searchQuery.ToLower())) &&
                                              !a.Ukryty);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_KursyList", kursy);
            }

            return View(kursy);
        }

        public ActionResult Szczegoly(int id)
        {
            var kurs = _db.Kursy.Find(id);
            return View(kurs);
        }
        [ChildActionOnly]
        [OutputCache(Duration =60000)]
        public ActionResult KategorieMenu()
        {

            var kategorie = _db.Kategorie.ToList();
            return PartialView("_KategorieMenu",kategorie);
        }

        public ActionResult KursyPodpowiedzi(string term)
        {
            var kursy = _db.Kursy.Where(a => !a.Ukryty && a.TytulKursu.ToLower().Contains(term.ToLower()))
                        .Take(5).Select(a => new { label = a.TytulKursu });

            return Json(kursy, JsonRequestBehavior.AllowGet);
        }
    }
}