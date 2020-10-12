namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialticket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InnerTickets", "File", c => c.String());
            AddColumn("dbo.InnerTickets", "User_UserID", c => c.Int());
            AddColumn("dbo.Tickets", "OrderDetails_ID", c => c.Int());
            AddColumn("dbo.Tickets", "Supporter_UserID", c => c.Int());
            AddColumn("dbo.Tickets", "TicketCategory_ID", c => c.Int());
            AddColumn("dbo.Tickets", "User_UserID1", c => c.Int());
            CreateIndex("dbo.InnerTickets", "User_UserID");
            CreateIndex("dbo.Tickets", "OrderDetails_ID");
            CreateIndex("dbo.Tickets", "Supporter_UserID");
            CreateIndex("dbo.Tickets", "TicketCategory_ID");
            CreateIndex("dbo.Tickets", "User_UserID1");
            AddForeignKey("dbo.Tickets", "OrderDetails_ID", "dbo.OrderDetails", "ID");
            AddForeignKey("dbo.Tickets", "Supporter_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Tickets", "TicketCategory_ID", "dbo.TicketCategories", "ID");
            AddForeignKey("dbo.InnerTickets", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Tickets", "User_UserID1", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "User_UserID1", "dbo.Users");
            DropForeignKey("dbo.InnerTickets", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Tickets", "TicketCategory_ID", "dbo.TicketCategories");
            DropForeignKey("dbo.Tickets", "Supporter_UserID", "dbo.Users");
            DropForeignKey("dbo.Tickets", "OrderDetails_ID", "dbo.OrderDetails");
            DropIndex("dbo.Tickets", new[] { "User_UserID1" });
            DropIndex("dbo.Tickets", new[] { "TicketCategory_ID" });
            DropIndex("dbo.Tickets", new[] { "Supporter_UserID" });
            DropIndex("dbo.Tickets", new[] { "OrderDetails_ID" });
            DropIndex("dbo.InnerTickets", new[] { "User_UserID" });
            DropColumn("dbo.Tickets", "User_UserID1");
            DropColumn("dbo.Tickets", "TicketCategory_ID");
            DropColumn("dbo.Tickets", "Supporter_UserID");
            DropColumn("dbo.Tickets", "OrderDetails_ID");
            DropColumn("dbo.InnerTickets", "User_UserID");
            DropColumn("dbo.InnerTickets", "File");
        }
    }
}
