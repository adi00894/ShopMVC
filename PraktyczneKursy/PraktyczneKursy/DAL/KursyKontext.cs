using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using PraktyczneKursy.Models;

namespace PraktyczneKursy.DAL
{
    public class KursyKontext : IdentityDbContext<ApplicationUser>
    {
        public KursyKontext() :base("KursyKontext")
        {
            
        }

        static KursyKontext()
        {
             Database.SetInitializer<KursyKontext>(new KursyInitializer());
        }

        public static KursyKontext Create()
        {
            return new KursyKontext();
        }

        public  DbSet<Kurs> Kursy { get; set; }
        public  DbSet<Kategoria> Kategorie { get; set; }
        public  DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<PozycjaZamowienia> PozycjeZamowienia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}