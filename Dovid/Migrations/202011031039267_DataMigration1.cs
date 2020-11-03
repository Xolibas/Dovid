namespace Dovid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Oblast = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainStations",
                c => new
                    {
                        Train_Id = c.Int(nullable: false),
                        Station_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Train_Id, t.Station_Id })
                .ForeignKey("dbo.Trains", t => t.Train_Id, cascadeDelete: true)
                .ForeignKey("dbo.Stations", t => t.Station_Id, cascadeDelete: true)
                .Index(t => t.Train_Id)
                .Index(t => t.Station_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainStations", "Station_Id", "dbo.Stations");
            DropForeignKey("dbo.TrainStations", "Train_Id", "dbo.Trains");
            DropIndex("dbo.TrainStations", new[] { "Station_Id" });
            DropIndex("dbo.TrainStations", new[] { "Train_Id" });
            DropTable("dbo.TrainStations");
            DropTable("dbo.Stations");
        }
    }
}
