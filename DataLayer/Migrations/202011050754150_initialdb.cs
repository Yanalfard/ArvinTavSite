namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "PackageService_ID", c => c.Int());
            AddColumn("dbo.Orders", "PackageService_ID", c => c.Int());
            AddColumn("dbo.PackageServices", "User_UserID", c => c.Int());
            CreateIndex("dbo.Tickets", "PackageService_ID");
            CreateIndex("dbo.PackageServices", "User_UserID");
            CreateIndex("dbo.Orders", "PackageService_ID");
            AddForeignKey("dbo.Orders", "PackageService_ID", "dbo.PackageServices", "ID");
            AddForeignKey("dbo.PackageServices", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Tickets", "PackageService_ID", "dbo.PackageServices", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "PackageService_ID", "dbo.PackageServices");
            DropForeignKey("dbo.PackageServices", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "PackageService_ID", "dbo.PackageServices");
            DropIndex("dbo.Orders", new[] { "PackageService_ID" });
            DropIndex("dbo.PackageServices", new[] { "User_UserID" });
            DropIndex("dbo.Tickets", new[] { "PackageService_ID" });
            DropColumn("dbo.PackageServices", "User_UserID");
            DropColumn("dbo.Orders", "PackageService_ID");
            DropColumn("dbo.Tickets", "PackageService_ID");
        }
    }
}
