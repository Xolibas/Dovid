namespace Buro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trains", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "Vagon");
            DropColumn("dbo.Tickets", "Place");
            DropColumn("dbo.Tickets", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "Place", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "Vagon", c => c.Int(nullable: false));
            DropColumn("dbo.Trains", "Price");
            DropColumn("dbo.Tickets", "Date");
        }
    }
}
