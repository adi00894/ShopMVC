namespace PraktyczneKursy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoria",
                c => new
                    {
                        KategoriaId = c.Int(nullable: false, identity: true),
                        NazwaKategorii = c.String(nullable: false, maxLength: 100),
                        OpisKategorii = c.String(nullable: false),
                        NazwaPlikuKategorii = c.String(),
                    })
                .PrimaryKey(t => t.KategoriaId);
            
            CreateTable(
                "dbo.Kurs",
                c => new
                    {
                        KursId = c.Int(nullable: false, identity: true),
                        KategoriaId = c.Int(nullable: false),
                        TytulKursu = c.String(nullable: false, maxLength: 100),
                        AutorKursu = c.String(nullable: false, maxLength: 100),
                        DataDodania = c.DateTime(nullable: false),
                        NazwaaPlikuObrazka = c.String(maxLength: 100),
                        OpisKursu = c.String(),
                        CenaKursu = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BestSeller = c.Boolean(nullable: false),
                        Ukryty = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KursId)
                .ForeignKey("dbo.Kategoria", t => t.KategoriaId, cascadeDelete: true)
                .Index(t => t.KategoriaId);
            
            CreateTable(
                "dbo.PozycjaZamowienia",
                c => new
                    {
                        PozycjaZamowieniaId = c.Int(nullable: false, identity: true),
                        ZamowienieId = c.Int(nullable: false),
                        KursId = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                        CenaZakupu = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Zamowienie_ZamowieniaId = c.Int(),
                    })
                .PrimaryKey(t => t.PozycjaZamowieniaId)
                .ForeignKey("dbo.Kurs", t => t.KursId, cascadeDelete: true)
                .ForeignKey("dbo.Zamowienie", t => t.Zamowienie_ZamowieniaId)
                .Index(t => t.KursId)
                .Index(t => t.Zamowienie_ZamowieniaId);
            
            CreateTable(
                "dbo.Zamowienie",
                c => new
                    {
                        ZamowieniaId = c.Int(nullable: false, identity: true),
                        Imie = c.String(nullable: false, maxLength: 50),
                        Nazwisko = c.String(nullable: false, maxLength: 50),
                        Ulica = c.String(nullable: false, maxLength: 100),
                        Miasto = c.String(nullable: false, maxLength: 50),
                        KodPocztowy = c.String(nullable: false, maxLength: 6),
                        Telefon = c.String(),
                        DataDodania = c.DateTime(nullable: false),
                        StanZamowienia = c.Int(nullable: false),
                        Wartosc = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ZamowieniaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PozycjaZamowienia", "Zamowienie_ZamowieniaId", "dbo.Zamowienie");
            DropForeignKey("dbo.PozycjaZamowienia", "KursId", "dbo.Kurs");
            DropForeignKey("dbo.Kurs", "KategoriaId", "dbo.Kategoria");
            DropIndex("dbo.PozycjaZamowienia", new[] { "Zamowienie_ZamowieniaId" });
            DropIndex("dbo.PozycjaZamowienia", new[] { "KursId" });
            DropIndex("dbo.Kurs", new[] { "KategoriaId" });
            DropTable("dbo.Zamowienie");
            DropTable("dbo.PozycjaZamowienia");
            DropTable("dbo.Kurs");
            DropTable("dbo.Kategoria");
        }
    }
}
