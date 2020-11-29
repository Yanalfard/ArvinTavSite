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
                        Title = c.String(maxLength: 50),
                        PhoneNumber = c.String(maxLength: 11),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 30),
                        Percentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.InnerTickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 200),
                        File = c.String(),
                        SideID = c.Int(),
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
                        Subject = c.String(maxLength: 500),
                        Status = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        EndTicketTime = c.DateTime(nullable: false),
                        User_UserID = c.Int(),
                        PackageService_ID = c.Int(),
                        Supporter_UserID = c.Int(),
                        TicketCategory_ID = c.Int(),
                        User_UserID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .ForeignKey("dbo.PackageServices", t => t.PackageService_ID)
                .ForeignKey("dbo.Users", t => t.Supporter_UserID)
                .ForeignKey("dbo.TicketCategories", t => t.TicketCategory_ID)
                .ForeignKey("dbo.Users", t => t.User_UserID1)
                .Index(t => t.User_UserID)
                .Index(t => t.PackageService_ID)
                .Index(t => t.Supporter_UserID)
                .Index(t => t.TicketCategory_ID)
                .Index(t => t.User_UserID1);
            
            CreateTable(
                "dbo.PackageServices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Description = c.String(),
                        Image = c.String(),
                        Price = c.Int(nullable: false),
                        OrderCount = c.Int(),
                        User_UserID = c.Int(),
                        ServiceCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_ID)
                .Index(t => t.User_UserID)
                .Index(t => t.ServiceCategory_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Description = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        PackageService_ID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PackageServices", t => t.PackageService_ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.PackageService_ID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        FullName = c.String(maxLength: 30),
                        Brand = c.String(maxLength: 30),
                        Email = c.String(maxLength: 80),
                        Image = c.String(),
                        PassWord = c.String(nullable: false, maxLength: 64),
                        AuthenticationCode = c.String(maxLength: 64),
                        Active = c.Boolean(nullable: false),
                        SignUpTime = c.DateTime(nullable: false),
                        FinalLoginTime = c.DateTime(nullable: false),
                        RegisterActiveTime = c.DateTime(nullable: false),
                        ForgetTime = c.DateTime(nullable: false),
                        UserRole_RoleID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.UserRoles", t => t.UserRole_RoleID)
                .Index(t => t.UserRole_RoleID);
            
            CreateTable(
                "dbo.MarketerReports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        DateTime = c.DateTime(nullable: false),
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
                        FullName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        PhoneNumber = c.String(maxLength: 11),
                        Text = c.String(maxLength: 1000),
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
                        Title = c.String(maxLength: 20),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.PackageServiceDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Response = c.String(maxLength: 100),
                        PackageService_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PackageServices", t => t.PackageService_ID)
                .Index(t => t.PackageService_ID);
            
            CreateTable(
                "dbo.ServiceCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(),
                        Title = c.String(maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        Description = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Spiders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Description = c.String(),
                        Image = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        SpiderCategory_ID = c.Int(),
                        ServiceCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SpiderCategories", t => t.SpiderCategory_ID)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_ID)
                .Index(t => t.SpiderCategory_ID)
                .Index(t => t.ServiceCategory_ID);
            
            CreateTable(
                "dbo.SeoTages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SideID = c.Int(nullable: false),
                        Tage = c.String(maxLength: 20),
                        ServiceCategory_ID = c.Int(),
                        Spider_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_ID)
                .ForeignKey("dbo.Spiders", t => t.Spider_ID)
                .Index(t => t.ServiceCategory_ID)
                .Index(t => t.Spider_ID);
            
            CreateTable(
                "dbo.SpiderCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TicketCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        PhoneNumber = c.String(maxLength: 11),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Image = c.String(),
                        Link = c.String(maxLength: 900),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 900),
                        Link = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "User_UserID1", "dbo.Users");
            DropForeignKey("dbo.Tickets", "TicketCategory_ID", "dbo.TicketCategories");
            DropForeignKey("dbo.Tickets", "Supporter_UserID", "dbo.Users");
            DropForeignKey("dbo.Tickets", "PackageService_ID", "dbo.PackageServices");
            DropForeignKey("dbo.Spiders", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropForeignKey("dbo.Spiders", "SpiderCategory_ID", "dbo.SpiderCategories");
            DropForeignKey("dbo.SeoTages", "Spider_ID", "dbo.Spiders");
            DropForeignKey("dbo.SeoTages", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropForeignKey("dbo.PackageServices", "ServiceCategory_ID", "dbo.ServiceCategories");
            DropForeignKey("dbo.PackageServiceDetails", "PackageService_ID", "dbo.PackageServices");
            DropForeignKey("dbo.Users", "UserRole_RoleID", "dbo.UserRoles");
            DropForeignKey("dbo.Tickets", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.PackageServices", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Massages", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.MarketerReports", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.InnerTickets", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "PackageService_ID", "dbo.PackageServices");
            DropForeignKey("dbo.InnerTickets", "Ticket_ID", "dbo.Tickets");
            DropIndex("dbo.SeoTages", new[] { "Spider_ID" });
            DropIndex("dbo.SeoTages", new[] { "ServiceCategory_ID" });
            DropIndex("dbo.Spiders", new[] { "ServiceCategory_ID" });
            DropIndex("dbo.Spiders", new[] { "SpiderCategory_ID" });
            DropIndex("dbo.PackageServiceDetails", new[] { "PackageService_ID" });
            DropIndex("dbo.Massages", new[] { "User_UserID" });
            DropIndex("dbo.MarketerReports", new[] { "User_UserID" });
            DropIndex("dbo.Users", new[] { "UserRole_RoleID" });
            DropIndex("dbo.Orders", new[] { "User_UserID" });
            DropIndex("dbo.Orders", new[] { "PackageService_ID" });
            DropIndex("dbo.PackageServices", new[] { "ServiceCategory_ID" });
            DropIndex("dbo.PackageServices", new[] { "User_UserID" });
            DropIndex("dbo.Tickets", new[] { "User_UserID1" });
            DropIndex("dbo.Tickets", new[] { "TicketCategory_ID" });
            DropIndex("dbo.Tickets", new[] { "Supporter_UserID" });
            DropIndex("dbo.Tickets", new[] { "PackageService_ID" });
            DropIndex("dbo.Tickets", new[] { "User_UserID" });
            DropIndex("dbo.InnerTickets", new[] { "User_UserID" });
            DropIndex("dbo.InnerTickets", new[] { "Ticket_ID" });
            DropTable("dbo.Sliders");
            DropTable("dbo.Projects");
            DropTable("dbo.Partners");
            DropTable("dbo.TicketCategories");
            DropTable("dbo.SpiderCategories");
            DropTable("dbo.SeoTages");
            DropTable("dbo.Spiders");
            DropTable("dbo.ServiceCategories");
            DropTable("dbo.PackageServiceDetails");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Massages");
            DropTable("dbo.MarketerReports");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.PackageServices");
            DropTable("dbo.Tickets");
            DropTable("dbo.InnerTickets");
            DropTable("dbo.Discounts");
            DropTable("dbo.Customers");
        }
    }
}
