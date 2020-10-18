namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editseotagengine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SeoTages", "SideID", c => c.Int(nullable: false));
            AddColumn("dbo.SeoTages", "ServiceCategory_ID", c => c.Int());
            CreateIndex("dbo.SeoTages", "ServiceCategory_ID");
            AddForeignKey("dbo.SeoTages", "ServiceCategory_ID", "dbo.ServiceCategories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeoTages", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropIndex("dbo.SeoTages", new[] { "ServiceCategory_ID" });
            DropColumn("dbo.SeoTages", "ServiceCategory_ID");
            DropColumn("dbo.SeoTages", "SideID");
        }
    }
}
