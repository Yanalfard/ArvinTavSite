namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DomainServices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Suffix = c.String(),
                        Price = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ServiceCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_ID)
                .Index(t => t.ServiceCategory_ID);
            
            CreateTable(
                "dbo.ServiceCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(),
                        Title = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Description = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HostingServices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Space = c.String(),
                        Monthly_Traffic = c.String(),
                        Sites_Be_Hosted = c.String(),
                        FreeSSL = c.Boolean(nullable: false),
                        Support = c.Boolean(nullable: false),
                        threeMonthsCost = c.Int(nullable: false),
                        SixMonthsCost = c.Int(nullable: false),
                        AnnuallyCost = c.Int(nullable: false),
                        ServiceCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_ID)
                .Index(t => t.ServiceCategory_ID);
            
            CreateTable(
                "dbo.HostingServiceDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Response = c.String(),
                        Kind = c.Int(nullable: false),
                        HostingService_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HostingServices", t => t.HostingService_ID)
                .Index(t => t.HostingService_ID);
            
            CreateTable(
                "dbo.PackageServices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        Price = c.Int(nullable: false),
                        ServiceCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_ID)
                .Index(t => t.ServiceCategory_ID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CategoryName = c.String(),
                        Price = c.Int(nullable: false),
                        Order_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.Order_ID)
                .Index(t => t.Order_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 15),
                        FullName = c.String(nullable: false, maxLength: 30),
                        PassWord = c.String(nullable: false, maxLength: 30),
                        ConfirmPassWord = c.String(nullable: false, maxLength: 30),
                        SignUpTime = c.DateTime(nullable: false),
                        FinalLoginTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.UserRoles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.TicketCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.UserRoles");
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "Order_ID", "dbo.Orders");
            DropForeignKey("dbo.PackageServices", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropForeignKey("dbo.HostingServices", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropForeignKey("dbo.HostingServiceDetails", "HostingService_ID", "dbo.HostingServices");
            DropForeignKey("dbo.DomainServices", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.OrderDetails", new[] { "Order_ID" });
            DropIndex("dbo.PackageServices", new[] { "ServiceCategory_ID" });
            DropIndex("dbo.HostingServiceDetails", new[] { "HostingService_ID" });
            DropIndex("dbo.HostingServices", new[] { "ServiceCategory_ID" });
            DropIndex("dbo.DomainServices", new[] { "ServiceCategory_ID" });
            DropTable("dbo.TicketCategories");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.PackageServices");
            DropTable("dbo.HostingServiceDetails");
            DropTable("dbo.HostingServices");
            DropTable("dbo.ServiceCategories");
            DropTable("dbo.DomainServices");
        }
    }
}
