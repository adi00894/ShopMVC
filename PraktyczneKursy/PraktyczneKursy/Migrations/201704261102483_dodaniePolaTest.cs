namespace PraktyczneKursy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodaniePolaTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kurs", "NazwaPlikuObrazka", c => c.String(maxLength: 100));
            AddColumn("dbo.Kurs", "OpisSkrocony", c => c.String());
            AddColumn("dbo.Kurs", "Test", c => c.String());
            DropColumn("dbo.Kurs", "NazwaaPlikuObrazka");
            DropColumn("dbo.Kurs", "OpisSkrovony");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kurs", "OpisSkrovony", c => c.String());
            AddColumn("dbo.Kurs", "NazwaaPlikuObrazka", c => c.String(maxLength: 100));
            DropColumn("dbo.Kurs", "Test");
            DropColumn("dbo.Kurs", "OpisSkrocony");
            DropColumn("dbo.Kurs", "NazwaPlikuObrazka");
        }
    }
}
