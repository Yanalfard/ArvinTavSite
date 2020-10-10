namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SideID = c.Int(nullable: false),
                        DomainService_ID = c.Int(),
                        HostingService_ID = c.Int(),
                        PackageService_ID = c.Int(),
                        ServiceCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DomainServices", t => t.DomainService_ID)
                .ForeignKey("dbo.HostingServices", t => t.HostingService_ID)
                .ForeignKey("dbo.PackageServices", t => t.PackageService_ID)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_ID)
                .Index(t => t.DomainService_ID)
                .Index(t => t.HostingService_ID)
                .Index(t => t.PackageService_ID)
                .Index(t => t.ServiceCategory_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropForeignKey("dbo.Products", "PackageService_ID", "dbo.PackageServices");
            DropForeignKey("dbo.Products", "HostingService_ID", "dbo.HostingServices");
            DropForeignKey("dbo.Products", "DomainService_ID", "dbo.DomainServices");
            DropIndex("dbo.Products", new[] { "ServiceCategory_ID" });
            DropIndex("dbo.Products", new[] { "PackageService_ID" });
            DropIndex("dbo.Products", new[] { "HostingService_ID" });
            DropIndex("dbo.Products", new[] { "DomainService_ID" });
            DropTable("dbo.Products");
        }
    }
}
