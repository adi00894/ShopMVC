using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PraktyczneKursy.DAL;
using PraktyczneKursy.Infrastructure;
using PraktyczneKursy.Models;
using PraktyczneKursy.ViewModels;

namespace PraktyczneKursy.Controllers
{
    public class HomeController : Controller
    {
        KursyKontext _db = new KursyKontext();

        // GET: Home
        public ActionResult Index()
        {
            ICacheProvider cache = new DefaultCacheProvider();

            List<Kategoria> kategorie;
            if (cache.IsSet(Consts.KategorieCacheKey))
            {
                kategorie = cache.Get(Consts.KategorieCacheKey) as List<Kategoria>;
            }
            else
            {
                kategorie = _db.Kategorie.ToList();
                cache.Set(Consts.KategorieCacheKey, kategorie, 60);
            }

            List<Kurs> nowosci;
            if (cache.IsSet(Consts.NowosciCacheKey))
            {
                nowosci = cache.Get(Consts.NowosciCacheKey) as List<Kurs>;
            }
            else
            {
                nowosci = _db.Kursy.Where(x => !x.Ukryty).OrderByDescending(x => x.DataDodania).Take(3).ToList();
                cache.Set(Consts.NowosciCacheKey, nowosci, 60);
            }

            List<Kurs> bestselery;
            if (cache.IsSet(Consts.BestselerCacheKey))
            {
                bestselery = cache.Get(Consts.BestselerCacheKey) as List<Kurs>;
            }
            else
            {
                bestselery = _db.Kursy.Where(x => !x.Ukryty && x.Bestseller).OrderBy(x => Guid.NewGuid()).Take(3).ToList();
                cache.Set(Consts.BestselerCacheKey, bestselery, 60);
            }

            var vm = new HomeViewModel
            {
                Kategorie = kategorie,
                Nowosci = nowosci,
                Bestselery = bestselery,
            };

            return View(vm);
        }

        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }
    }
}