using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PraktyczneKursy.Models;

namespace PraktyczneKursy.ViewModels
{
    public class KoszykViewModel
    {
        public List<PozycjaKoszyka> PozycjeKoszyka { get; set; }
        public decimal CenaCalkowita { get; set; }
    }
}