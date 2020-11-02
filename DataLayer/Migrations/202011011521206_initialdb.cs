namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PhoneNumber = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Percentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DomainServiceOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DomainName = c.String(),
                        DomainService_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DomainServices", t => t.DomainService_ID)
                .Index(t => t.DomainService_ID);
            
            CreateTable(
                "dbo.DomainServices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Suffix = c.String(),
                        Price = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        OrderCount = c.Int(),
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
                        OrderCount = c.Int(),
                        ServiceCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_ID)
                .Index(t => t.ServiceCategory_ID);
            
            CreateTable(
                "dbo.HostingOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExpirationHostSide = c.Int(nullable: false),
                        DomainName = c.String(),
                        DomainService_ID = c.Int(),
                        HostingService_ID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DomainServices", t => t.DomainService_ID)
                .ForeignKey("dbo.HostingServices", t => t.HostingService_ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.DomainService_ID)
                .Index(t => t.HostingService_ID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(nullable: false, maxLength: 15),
                        FullName = c.String(maxLength: 30),
                        Brand = c.String(maxLength: 30),
                        Email = c.String(),
                        Image = c.String(),
                        PassWord = c.String(nullable: false, maxLength: 64),
                        AuthenticationCode = c.String(maxLength: 64),
                        Active = c.Boolean(nullable: false),
                        SignUpTime = c.DateTime(),
                        FinalLoginTime = c.DateTime(nullable: false),
                        RegisterActiveTime = c.DateTime(nullable: false),
                        ForgetTime = c.DateTime(nullable: false),
                        UserRole_RoleID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.UserRoles", t => t.UserRole_RoleID)
                .Index(t => t.UserRole_RoleID);
            
            CreateTable(
                "dbo.InnerTickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        File = c.String(),
                        ParentID = c.Int(),
                        dateTime = c.DateTime(nullable: false),
                        Ticket_ID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tickets", t => t.Ticket_ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.Ticket_ID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Status = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        EndTicketTime = c.DateTime(nullable: false),
                        OrderDetails_ID = c.Int(),
                        Supporter_UserID = c.Int(),
                        TicketCategory_ID = c.Int(),
                        User_UserID = c.Int(),
                        User_UserID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetails_ID)
                .ForeignKey("dbo.Users", t => t.Supporter_UserID)
                .ForeignKey("dbo.TicketCategories", t => t.TicketCategory_ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .ForeignKey("dbo.Users", t => t.User_UserID1)
                .Index(t => t.OrderDetails_ID)
                .Index(t => t.Supporter_UserID)
                .Index(t => t.TicketCategory_ID)
                .Index(t => t.User_UserID)
                .Index(t => t.User_UserID1);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        SideID = c.Int(nullable: false),
                        DomainServiceOrder_ID = c.Int(),
                        HostingOrder_ID = c.Int(),
                        Order_ID = c.Int(),
                        PackageService_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DomainServiceOrders", t => t.DomainServiceOrder_ID)
                .ForeignKey("dbo.HostingOrders", t => t.HostingOrder_ID)
                .ForeignKey("dbo.Orders", t => t.Order_ID)
                .ForeignKey("dbo.PackageServices", t => t.PackageService_ID)
                .Index(t => t.DomainServiceOrder_ID)
                .Index(t => t.HostingOrder_ID)
                .Index(t => t.Order_ID)
                .Index(t => t.PackageService_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.String(),
                        Status = c.Int(nullable: false),
                        Description = c.String(maxLength: 600),
                        DateTime = c.DateTime(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.PackageServices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        Price = c.Int(nullable: false),
                        OrderCount = c.Int(),
                        ServiceCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_ID)
                .Index(t => t.ServiceCategory_ID);
            
            CreateTable(
                "dbo.TicketCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MarketerReports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Massages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 500),
                        Seen = c.Boolean(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
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
                "dbo.Spiders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        ServiceCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_ID)
                .Index(t => t.ServiceCategory_ID);
            
            CreateTable(
                "dbo.SeoTages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SideID = c.Int(nullable: false),
                        Tage = c.String(),
                        ServiceCategory_ID = c.Int(),
                        Spider_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_ID)
                .ForeignKey("dbo.Spiders", t => t.Spider_ID)
                .Index(t => t.ServiceCategory_ID)
                .Index(t => t.Spider_ID);
            
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PhoneNumber = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Image = c.String(),
                        Link = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Link = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropForeignKey("dbo.Products", "PackageService_ID", "dbo.PackageServices");
            DropForeignKey("dbo.Products", "HostingService_ID", "dbo.HostingServices");
            DropForeignKey("dbo.Products", "DomainService_ID", "dbo.DomainServices");
            DropForeignKey("dbo.Spiders", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropForeignKey("dbo.SeoTages", "Spider_ID", "dbo.Spiders");
            DropForeignKey("dbo.SeoTages", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropForeignKey("dbo.HostingServices", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropForeignKey("dbo.HostingServiceDetails", "HostingService_ID", "dbo.HostingServices");
            DropForeignKey("dbo.Users", "UserRole_RoleID", "dbo.UserRoles");
            DropForeignKey("dbo.Tickets", "User_UserID1", "dbo.Users");
            DropForeignKey("dbo.Massages", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.MarketerReports", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.InnerTickets", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Tickets", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Tickets", "TicketCategory_ID", "dbo.TicketCategories");
            DropForeignKey("dbo.Tickets", "Supporter_UserID", "dbo.Users");
            DropForeignKey("dbo.Tickets", "OrderDetails_ID", "dbo.OrderDetails");
            DropForeignKey("dbo.PackageServices", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropForeignKey("dbo.OrderDetails", "PackageService_ID", "dbo.PackageServices");
            DropForeignKey("dbo.Orders", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "Order_ID", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "HostingOrder_ID", "dbo.HostingOrders");
            DropForeignKey("dbo.OrderDetails", "DomainServiceOrder_ID", "dbo.DomainServiceOrders");
            DropForeignKey("dbo.InnerTickets", "Ticket_ID", "dbo.Tickets");
            DropForeignKey("dbo.HostingOrders", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.HostingOrders", "HostingService_ID", "dbo.HostingServices");
            DropForeignKey("dbo.HostingOrders", "DomainService_ID", "dbo.DomainServices");
            DropForeignKey("dbo.DomainServices", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropForeignKey("dbo.DomainServiceOrders", "DomainService_ID", "dbo.DomainServices");
            DropIndex("dbo.Products", new[] { "ServiceCategory_ID" });
            DropIndex("dbo.Products", new[] { "PackageService_ID" });
            DropIndex("dbo.Products", new[] { "HostingService_ID" });
            DropIndex("dbo.Products", new[] { "DomainService_ID" });
            DropIndex("dbo.SeoTages", new[] { "Spider_ID" });
            DropIndex("dbo.SeoTages", new[] { "ServiceCategory_ID" });
            DropIndex("dbo.Spiders", new[] { "ServiceCategory_ID" });
            DropIndex("dbo.HostingServiceDetails", new[] { "HostingService_ID" });
            DropIndex("dbo.Massages", new[] { "User_UserID" });
            DropIndex("dbo.MarketerReports", new[] { "User_UserID" });
            DropIndex("dbo.PackageServices", new[] { "ServiceCategory_ID" });
            DropIndex("dbo.Orders", new[] { "User_UserID" });
            DropIndex("dbo.OrderDetails", new[] { "PackageService_ID" });
            DropIndex("dbo.OrderDetails", new[] { "Order_ID" });
            DropIndex("dbo.OrderDetails", new[] { "HostingOrder_ID" });
            DropIndex("dbo.OrderDetails", new[] { "DomainServiceOrder_ID" });
            DropIndex("dbo.Tickets", new[] { "User_UserID1" });
            DropIndex("dbo.Tickets", new[] { "User_UserID" });
            DropIndex("dbo.Tickets", new[] { "TicketCategory_ID" });
            DropIndex("dbo.Tickets", new[] { "Supporter_UserID" });
            DropIndex("dbo.Tickets", new[] { "OrderDetails_ID" });
            DropIndex("dbo.InnerTickets", new[] { "User_UserID" });
            DropIndex("dbo.InnerTickets", new[] { "Ticket_ID" });
            DropIndex("dbo.Users", new[] { "UserRole_RoleID" });
            DropIndex("dbo.HostingOrders", new[] { "User_UserID" });
            DropIndex("dbo.HostingOrders", new[] { "HostingService_ID" });
            DropIndex("dbo.HostingOrders", new[] { "DomainService_ID" });
            DropIndex("dbo.HostingServices", new[] { "ServiceCategory_ID" });
            DropIndex("dbo.DomainServices", new[] { "ServiceCategory_ID" });
            DropIndex("dbo.DomainServiceOrders", new[] { "DomainService_ID" });
            DropTable("dbo.Sliders");
            DropTable("dbo.Projects");
            DropTable("dbo.Products");
            DropTable("dbo.Partners");
            DropTable("dbo.SeoTages");
            DropTable("dbo.Spiders");
            DropTable("dbo.HostingServiceDetails");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Massages");
            DropTable("dbo.MarketerReports");
            DropTable("dbo.TicketCategories");
            DropTable("dbo.PackageServices");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Tickets");
            DropTable("dbo.InnerTickets");
            DropTable("dbo.Users");
            DropTable("dbo.HostingOrders");
            DropTable("dbo.HostingServices");
            DropTable("dbo.ServiceCategories");
            DropTable("dbo.DomainServices");
            DropTable("dbo.DomainServiceOrders");
            DropTable("dbo.Discounts");
            DropTable("dbo.Customers");
        }
    }
}
