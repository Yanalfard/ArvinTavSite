namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Ticket_Project_Table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "UserID" });
            RenameColumn(table: "dbo.Orders", name: "UserID", newName: "User_UserID");
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Image = c.String(),
                        Link = c.String(),
                        Status = c.Int(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.InnerTickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        ParentID = c.Int(),
                        dateTime = c.DateTime(nullable: false),
                        Ticket_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tickets", t => t.Ticket_ID)
                .Index(t => t.Ticket_ID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Status = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        EndTicketTime = c.DateTime(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            AddColumn("dbo.OrderDetails", "DomainService_ID", c => c.Int());
            AddColumn("dbo.OrderDetails", "HostingService_ID", c => c.Int());
            AddColumn("dbo.OrderDetails", "PackageService_ID", c => c.Int());
            AlterColumn("dbo.Orders", "User_UserID", c => c.Int());
            CreateIndex("dbo.OrderDetails", "DomainService_ID");
            CreateIndex("dbo.OrderDetails", "HostingService_ID");
            CreateIndex("dbo.OrderDetails", "PackageService_ID");
            CreateIndex("dbo.Orders", "User_UserID");
            AddForeignKey("dbo.OrderDetails", "DomainService_ID", "dbo.DomainServices", "ID");
            AddForeignKey("dbo.OrderDetails", "HostingService_ID", "dbo.HostingServices", "ID");
            AddForeignKey("dbo.OrderDetails", "PackageService_ID", "dbo.PackageServices", "ID");
            AddForeignKey("dbo.Orders", "User_UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Tickets", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.InnerTickets", "Ticket_ID", "dbo.Tickets");
            DropForeignKey("dbo.Projects", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "PackageService_ID", "dbo.PackageServices");
            DropForeignKey("dbo.OrderDetails", "HostingService_ID", "dbo.HostingServices");
            DropForeignKey("dbo.OrderDetails", "DomainService_ID", "dbo.DomainServices");
            DropIndex("dbo.Tickets", new[] { "User_UserID" });
            DropIndex("dbo.InnerTickets", new[] { "Ticket_ID" });
            DropIndex("dbo.Projects", new[] { "User_UserID" });
            DropIndex("dbo.Orders", new[] { "User_UserID" });
            DropIndex("dbo.OrderDetails", new[] { "PackageService_ID" });
            DropIndex("dbo.OrderDetails", new[] { "HostingService_ID" });
            DropIndex("dbo.OrderDetails", new[] { "DomainService_ID" });
            AlterColumn("dbo.Orders", "User_UserID", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "PackageService_ID");
            DropColumn("dbo.OrderDetails", "HostingService_ID");
            DropColumn("dbo.OrderDetails", "DomainService_ID");
            DropTable("dbo.Tickets");
            DropTable("dbo.InnerTickets");
            DropTable("dbo.Projects");
            RenameColumn(table: "dbo.Orders", name: "User_UserID", newName: "UserID");
            CreateIndex("dbo.Orders", "UserID");
            AddForeignKey("dbo.Orders", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
