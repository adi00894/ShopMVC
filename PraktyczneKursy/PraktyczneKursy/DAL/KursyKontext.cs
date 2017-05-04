using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using PraktyczneKursy.Models;

namespace PraktyczneKursy.DAL
{
    public class KursyKontext : DbContext
    {
        public KursyKontext() :base("KursyKontext")
        {
            
        }

        static KursyKontext()
        {
             Database.SetInitializer<KursyKontext>(new KursyInitializer());
        }

        public DbSet<Kurs> Kursy { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<PozycjaZamowienia> PozycjaZamowienia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}