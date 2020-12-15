namespace Dovid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "TrainId", "dbo.Trains");
            DropIndex("dbo.Tickets", new[] { "TrainId" });
            AlterColumn("dbo.Stations", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Stations", "Oblast", c => c.String(nullable: false));
            AlterColumn("dbo.Trains", "SPos", c => c.String(nullable: false));
            AlterColumn("dbo.Trains", "FPos", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "TrainId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "Sname", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "Adress", c => c.String(nullable: false));
            CreateIndex("dbo.Tickets", "TrainId");
            AddForeignKey("dbo.Tickets", "TrainId", "dbo.Trains", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TrainId", "dbo.Trains");
            DropIndex("dbo.Tickets", new[] { "TrainId" });
            AlterColumn("dbo.Tickets", "Adress", c => c.String());
            AlterColumn("dbo.Tickets", "Sname", c => c.String());
            AlterColumn("dbo.Tickets", "Name", c => c.String());
            AlterColumn("dbo.Tickets", "TrainId", c => c.Int());
            AlterColumn("dbo.Trains", "FPos", c => c.String());
            AlterColumn("dbo.Trains", "SPos", c => c.String());
            AlterColumn("dbo.Stations", "Oblast", c => c.String());
            AlterColumn("dbo.Stations", "Name", c => c.String());
            CreateIndex("dbo.Tickets", "TrainId");
            AddForeignKey("dbo.Tickets", "TrainId", "dbo.Trains", "Id");
        }
    }
}
