namespace Dovid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trains", "SPos", c => c.String(nullable: false));
            AlterColumn("dbo.Trains", "FPos", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trains", "FPos", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Trains", "SPos", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
