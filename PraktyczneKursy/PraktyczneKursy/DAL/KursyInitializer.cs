﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Security.Cryptography.X509Certificates;
using PraktyczneKursy.Models;


namespace PraktyczneKursy.DAL
{
    public class KursyInitializer : MigrateDatabaseToLatestVersion<KursyKontext, PraktyczneKursy.Migrations.Configuration>
    {
            
        public static void SeedKursyData(KursyKontext context)
        {
             

            var kategorie = new List<Kategoria>
            {
                new Kategoria() { KategoriaId=1, NazwaKategorii="Asp.Net", NazwaPlikuKategorii="aspnet.png", OpisKategorii="programowanie w asp net" },
                new Kategoria() { KategoriaId=2, NazwaKategorii="JavaScript", NazwaPlikuKategorii="javascript.png", OpisKategorii="skryptowy język programowania" },
                new Kategoria() { KategoriaId=3, NazwaKategorii="jQuery", NazwaPlikuKategorii="jquery.png", OpisKategorii="lekka biblioteka programistyczna dla języka JavaScript" },
                new Kategoria() { KategoriaId=4, NazwaKategorii="Html5", NazwaPlikuKategorii="html.png", OpisKategorii="język wykorzystywany do tworzenia i prezentowania stron internetowych www" },
                new Kategoria() { KategoriaId=5, NazwaKategorii="Css3", NazwaPlikuKategorii="css.png", OpisKategorii="język służący do opisu formy prezentacji (wyświetlania) stron www" },
                new Kategoria() { KategoriaId=6, NazwaKategorii="Xml", NazwaPlikuKategorii="xml.png", OpisKategorii="uniwersalny język znaczników przeznaczony do reprezentowania różnych danych w strukturalizowany sposób" },
                new Kategoria() { KategoriaId=7, NazwaKategorii="C#", NazwaPlikuKategorii="csharp.png", OpisKategorii="obiektowy język programowania zaprojektowany dla platformy .Net" }
            };

            kategorie.ForEach(k => context.Kategorie.AddOrUpdate(k));
            context.SaveChanges();

            var kursy = new List<Kurs>
            {
                new Kurs() { KursId=1, AutorKursu="Adrian", TytulKursu="Asp.Net", KategoriaId=1, CenaKursu=0, Bestseller=true, NazwaPlikuObrazka= "obrazekaspnet.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs ASP.NET - doskonała platforma do tworzenia dynamicznych aplikacji internetowych. Kurs jest przeznaczony dla wszystkich osób, które chcą nauczyć się od podstaw tworzenia stron internetowych wykorzystując technologię ASP-NET."},
                new Kurs() { KursId=2, AutorKursu="Adrian", TytulKursu="Asp.Net Mvc", KategoriaId=1, CenaKursu=0, Bestseller=true, NazwaPlikuObrazka="obrazekmvc.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs ASP.NET MVC - przeznaczony jest dla wszystkich osób, które chcą nauczyć się od podstaw tworzenia stron internetowych wykorzystując technologię ASP-NET MVC."},
                new Kurs() { KursId=3, AutorKursu="Adrian", TytulKursu="Asp.Net Mvc - Sklep Internetowy", KategoriaId=1, CenaKursu=100, Bestseller= true, NazwaPlikuObrazka="obrazekmvc2.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs Asp.Net Mvc - Sklep Internetowy - to praktyczne rozwiązanie wykorzystujące technologię Asp.Net Mvc pokazujące krok po kroku budowanie serwisu internetowego sprzedającego kursy on-line"},

                new Kurs() { KursId=4, AutorKursu="Adrian", TytulKursu="JavaScript", KategoriaId=2, CenaKursu=70, Bestseller=false, NazwaPlikuObrazka="obrazekjavascript.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs JavaScript - skryptowy język programowania"},
                new Kurs() { KursId=5, AutorKursu="Adrian", TytulKursu="jQuery", KategoriaId=3, CenaKursu=90, Bestseller=true, NazwaPlikuObrazka="obrazekjquery.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs jQuery - lekka biblioteka programistyczna dla języka JavaScript"},
                new Kurs() { KursId=6, AutorKursu="Adrian", TytulKursu="Html5", KategoriaId=4, CenaKursu=70, Bestseller=false, NazwaPlikuObrazka="obrazekhtml.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs Html5 - język wykorzystywany do tworzenia i prezentowania stron internetowych www"},

                new Kurs() { KursId=7, AutorKursu="Adrian", TytulKursu="Css3", KategoriaId=5, CenaKursu=70, Bestseller= false, NazwaPlikuObrazka="obrazekcss.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs Css3 - język służący do opisu formy prezentacji (wyświetlania) stron www"},
                new Kurs() { KursId=8, AutorKursu="Adrian", TytulKursu="Xml", KategoriaId=6, CenaKursu=60, Bestseller=false, NazwaPlikuObrazka="obrazekxml.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs Xml - uniwersalny język znaczników przeznaczony do reprezentowania różnych danych w strukturalizowany sposób"},
                new Kurs() { KursId=9, AutorKursu="Adrian", TytulKursu="C#", KategoriaId=7, CenaKursu=90, Bestseller=true, NazwaPlikuObrazka="obrazekcsharp.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs C# - obiektowy język programowania zaprojektowany dla platformy .Net"}

            };
            kursy.ForEach(k => context.Kursy.AddOrUpdate(k));
            context.SaveChanges();

        }

       
        
    }
}