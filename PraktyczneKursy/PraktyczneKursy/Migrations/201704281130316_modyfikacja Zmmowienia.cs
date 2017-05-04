namespace PraktyczneKursy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modyfikacjaZmmowienia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zamowienie", "UserId", c => c.String());
            AddColumn("dbo.Zamowienie", "Adres", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Zamowienie", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Zamowienie", "Komentarz", c => c.String());
            AddColumn("dbo.Zamowienie", "WartoscZamowienia", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Zamowienie", "Telefon", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Zamowienie", "Ulica");
            DropColumn("dbo.Zamowienie", "Wartosc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zamowienie", "Wartosc", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Zamowienie", "Ulica", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Zamowienie", "Telefon", c => c.String());
            DropColumn("dbo.Zamowienie", "WartoscZamowienia");
            DropColumn("dbo.Zamowienie", "Komentarz");
            DropColumn("dbo.Zamowienie", "Email");
            DropColumn("dbo.Zamowienie", "Adres");
            DropColumn("dbo.Zamowienie", "UserId");
        }
    }
}
