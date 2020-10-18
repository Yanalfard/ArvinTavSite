namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialtest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Packages", "CatID", "dbo.Categories");
            DropForeignKey("dbo.Comments", "PackID", "dbo.Packages");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Packages", "UserID", "dbo.Users");
            DropForeignKey("dbo.Proposals", "UserID", "dbo.Users");
            DropForeignKey("dbo.PackageGalleries", "DocID", "dbo.documents");
            DropForeignKey("dbo.PackageGalleries", "PackID", "dbo.Packages");
            DropForeignKey("dbo.Packages", "SourceID", "dbo.PackageSources");
            DropForeignKey("dbo.SeoTages", "PackID", "dbo.Packages");
            DropForeignKey("dbo.Packages", "VersionID", "dbo.Versions");
            DropForeignKey("dbo.Vitrins", "CatID", "dbo.Categories");
            DropIndex("dbo.Packages", new[] { "CatID" });
            DropIndex("dbo.Packages", new[] { "SourceID" });
            DropIndex("dbo.Packages", new[] { "VersionID" });
            DropIndex("dbo.Packages", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "PackID" });
            DropIndex("dbo.Proposals", new[] { "UserID" });
            DropIndex("dbo.PackageGalleries", new[] { "PackID" });
            DropIndex("dbo.PackageGalleries", new[] { "DocID" });
            DropIndex("dbo.SeoTages", new[] { "PackID" });
            DropIndex("dbo.Vitrins", new[] { "CatID" });
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
                        Price = c.String(),
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
                        threeMonthsCost = c.String(),
                        SixMonthsCost = c.String(),
                        AnnuallyCost = c.String(),
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
                        Price = c.Int(nullable: false),
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
                        Price = c.String(),
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
                        Status = c.Boolean(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
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
                "dbo.Spiders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "FullName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Users", "Brand", c => c.String(maxLength: 300));
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "Image", c => c.String());
            AddColumn("dbo.Users", "PassWord", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Users", "ConfirmPassWord", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Users", "SignUpTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "FinalLoginTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserRoles", "Title", c => c.String());
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false, maxLength: 15));
            DropColumn("dbo.Users", "UserFullName");
            DropColumn("dbo.Users", "UserPassWord");
            DropColumn("dbo.Users", "UserConfirmPassWord");
            DropColumn("dbo.Users", "UserImage");
            DropColumn("dbo.Users", "UserRegisterTime");
            DropColumn("dbo.Users", "UserFinalLoginTime");
            DropColumn("dbo.UserRoles", "RoleName");
            DropTable("dbo.Advertisings");
            DropTable("dbo.Categories");
            DropTable("dbo.Packages");
            DropTable("dbo.Comments");
            DropTable("dbo.Proposals");
            DropTable("dbo.PackageGalleries");
            DropTable("dbo.documents");
            DropTable("dbo.PackageSources");
            DropTable("dbo.SeoTages");
            DropTable("dbo.Versions");
            DropTable("dbo.Vitrins");
            DropTable("dbo.Sliders");
            DropTable("dbo.StateSites");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StateSites",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StateID);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SliderID = c.Int(nullable: false, identity: true),
                        SliderImg = c.String(),
                        SliderLink = c.String(),
                        SliderTitle = c.String(),
                        Category = c.Int(nullable: false),
                        dividerImage = c.String(),
                        dividerTitle = c.String(),
                        dividerLink = c.String(),
                    })
                .PrimaryKey(t => t.SliderID);
            
            CreateTable(
                "dbo.Vitrins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CatID = c.Int(nullable: false),
                        ViewCategory = c.Int(nullable: false),
                        DeviceCategory = c.Int(nullable: false),
                        Name = c.String(),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Versions",
                c => new
                    {
                        VersionID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        InnerVersionID = c.Int(),
                    })
                .PrimaryKey(t => t.VersionID);
            
            CreateTable(
                "dbo.SeoTages",
                c => new
                    {
                        SeoTageID = c.Int(nullable: false, identity: true),
                        PackID = c.Int(nullable: false),
                        Tage = c.String(),
                    })
                .PrimaryKey(t => t.SeoTageID);
            
            CreateTable(
                "dbo.PackageSources",
                c => new
                    {
                        SourceID = c.Int(nullable: false, identity: true),
                        SourceName = c.String(),
                        SourceLink = c.String(),
                        SourceActive = c.Boolean(nullable: false),
                        SourcePackCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SourceID);
            
            CreateTable(
                "dbo.documents",
                c => new
                    {
                        DocID = c.Int(nullable: false, identity: true),
                        DocName = c.String(),
                        DocLink = c.String(),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocID);
            
            CreateTable(
                "dbo.PackageGalleries",
                c => new
                    {
                        ImgID = c.Int(nullable: false, identity: true),
                        PackID = c.Int(nullable: false),
                        DocID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImgID);
            
            CreateTable(
                "dbo.Proposals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Seen = c.Boolean(nullable: false),
                        Text = c.String(maxLength: 600),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PackID = c.Int(nullable: false),
                        Text = c.String(maxLength: 300),
                        Status = c.Int(nullable: false),
                        reply = c.String(),
                        responderName = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommID);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        PackID = c.Int(nullable: false, identity: true),
                        CatID = c.Int(nullable: false),
                        SourceID = c.Int(nullable: false),
                        VersionID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Title = c.String(),
                        SearchTitle = c.String(),
                        Short_Description = c.String(),
                        Description = c.String(),
                        Cost = c.Boolean(nullable: false),
                        Price = c.Int(),
                        Logo_Img = c.String(),
                        Compatible = c.String(),
                        Ages = c.String(),
                        FileSize = c.String(),
                        DownloadType = c.Boolean(nullable: false),
                        FileLink = c.String(),
                        FilePassword = c.String(),
                        Status = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        FinalEditTime = c.DateTime(nullable: false),
                        DownloadCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PackID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CatID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ChildCatID = c.Int(),
                        SubCatID = c.Int(),
                        SubKindID = c.Int(),
                    })
                .PrimaryKey(t => t.CatID);
            
            CreateTable(
                "dbo.Advertisings",
                c => new
                    {
                        AdID = c.Int(nullable: false, identity: true),
                        AdName = c.String(),
                        AdImage = c.String(),
                        AdLink = c.String(),
                        Category = c.Int(nullable: false),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.AdID);
            
            AddColumn("dbo.UserRoles", "RoleName", c => c.String());
            AddColumn("dbo.Users", "UserFinalLoginTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "UserRegisterTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "UserImage", c => c.String());
            AddColumn("dbo.Users", "UserConfirmPassWord", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "UserPassWord", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "UserFullName", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Products", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropForeignKey("dbo.Products", "PackageService_ID", "dbo.PackageServices");
            DropForeignKey("dbo.Products", "HostingService_ID", "dbo.HostingServices");
            DropForeignKey("dbo.Products", "DomainService_ID", "dbo.DomainServices");
            DropForeignKey("dbo.HostingServices", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropForeignKey("dbo.HostingServiceDetails", "HostingService_ID", "dbo.HostingServices");
            DropForeignKey("dbo.Tickets", "User_UserID1", "dbo.Users");
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
            DropIndex("dbo.HostingServiceDetails", new[] { "HostingService_ID" });
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
            DropIndex("dbo.HostingOrders", new[] { "User_UserID" });
            DropIndex("dbo.HostingOrders", new[] { "HostingService_ID" });
            DropIndex("dbo.HostingOrders", new[] { "DomainService_ID" });
            DropIndex("dbo.HostingServices", new[] { "ServiceCategory_ID" });
            DropIndex("dbo.DomainServices", new[] { "ServiceCategory_ID" });
            DropIndex("dbo.DomainServiceOrders", new[] { "DomainService_ID" });
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false, maxLength: 18));
            DropColumn("dbo.UserRoles", "Title");
            DropColumn("dbo.Users", "FinalLoginTime");
            DropColumn("dbo.Users", "SignUpTime");
            DropColumn("dbo.Users", "ConfirmPassWord");
            DropColumn("dbo.Users", "PassWord");
            DropColumn("dbo.Users", "Image");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "Brand");
            DropColumn("dbo.Users", "FullName");
            DropTable("dbo.Spiders");
            DropTable("dbo.Projects");
            DropTable("dbo.Products");
            DropTable("dbo.HostingServiceDetails");
            DropTable("dbo.MarketerReports");
            DropTable("dbo.TicketCategories");
            DropTable("dbo.PackageServices");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Tickets");
            DropTable("dbo.InnerTickets");
            DropTable("dbo.HostingOrders");
            DropTable("dbo.HostingServices");
            DropTable("dbo.ServiceCategories");
            DropTable("dbo.DomainServices");
            DropTable("dbo.DomainServiceOrders");
            CreateIndex("dbo.Vitrins", "CatID");
            CreateIndex("dbo.SeoTages", "PackID");
            CreateIndex("dbo.PackageGalleries", "DocID");
            CreateIndex("dbo.PackageGalleries", "PackID");
            CreateIndex("dbo.Proposals", "UserID");
            CreateIndex("dbo.Comments", "PackID");
            CreateIndex("dbo.Comments", "UserID");
            CreateIndex("dbo.Packages", "UserID");
            CreateIndex("dbo.Packages", "VersionID");
            CreateIndex("dbo.Packages", "SourceID");
            CreateIndex("dbo.Packages", "CatID");
            AddForeignKey("dbo.Vitrins", "CatID", "dbo.Categories", "CatID", cascadeDelete: true);
            AddForeignKey("dbo.Packages", "VersionID", "dbo.Versions", "VersionID", cascadeDelete: true);
            AddForeignKey("dbo.SeoTages", "PackID", "dbo.Packages", "PackID", cascadeDelete: true);
            AddForeignKey("dbo.Packages", "SourceID", "dbo.PackageSources", "SourceID", cascadeDelete: true);
            AddForeignKey("dbo.PackageGalleries", "PackID", "dbo.Packages", "PackID", cascadeDelete: true);
            AddForeignKey("dbo.PackageGalleries", "DocID", "dbo.documents", "DocID", cascadeDelete: true);
            AddForeignKey("dbo.Proposals", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Packages", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "PackID", "dbo.Packages", "PackID", cascadeDelete: true);
            AddForeignKey("dbo.Packages", "CatID", "dbo.Categories", "CatID", cascadeDelete: true);
        }
    }
}
