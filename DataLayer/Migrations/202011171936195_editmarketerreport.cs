namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editmarketerreport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MarketerReports", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MarketerReports", "DateTime");
        }
    }
}
