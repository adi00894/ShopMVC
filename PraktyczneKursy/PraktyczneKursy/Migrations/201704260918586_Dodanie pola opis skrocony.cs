namespace PraktyczneKursy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dodaniepolaopisskrocony : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kurs", "OpisSkrovony", c => c.String());
            RenameColumn("dbo.Kurs", "BestSeller", "Bestseller");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kurs", "OpisSkrovony");
            RenameColumn("dbo.Kurs", "Bestseller", "BestSeller");
        }
    }
}
