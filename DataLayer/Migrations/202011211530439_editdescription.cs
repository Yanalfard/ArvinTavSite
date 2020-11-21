namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editdescription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PackageServices", "Description", c => c.String());
            AlterColumn("dbo.Orders", "Description", c => c.String());
            AlterColumn("dbo.MarketerReports", "Description", c => c.String());
            AlterColumn("dbo.ServiceCategories", "Description", c => c.String());
            AlterColumn("dbo.Spiders", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Spiders", "Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.ServiceCategories", "Description", c => c.String(maxLength: 600));
            AlterColumn("dbo.MarketerReports", "Description", c => c.String(maxLength: 600));
            AlterColumn("dbo.Orders", "Description", c => c.String(maxLength: 600));
            AlterColumn("dbo.PackageServices", "Description", c => c.String(maxLength: 1000));
        }
    }
}
