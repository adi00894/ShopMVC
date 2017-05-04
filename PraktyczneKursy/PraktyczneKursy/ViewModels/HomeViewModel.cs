using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PraktyczneKursy.Models;

namespace PraktyczneKursy.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Kategoria> Kategorie { get; set; }
        public IEnumerable<Kurs> Nowosci { get; set; }
        public IEnumerable<Kurs> Bestselery { get; set; }
    }
}