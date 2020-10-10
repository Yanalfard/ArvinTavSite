namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editorder3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "DomainService_ID", "dbo.DomainServices");
            DropIndex("dbo.OrderDetails", new[] { "Product_ID" });
            DropIndex("dbo.OrderDetails", new[] { "DomainService_ID" });
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
            
            AddColumn("dbo.OrderDetails", "SideID", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "DomainServiceOrder_ID", c => c.Int());
            AddColumn("dbo.OrderDetails", "HostingOrder_ID", c => c.Int());
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.HostingOrders", "DomainService_ID", c => c.Int());
            AddColumn("dbo.HostingOrders", "User_UserID", c => c.Int());
            CreateIndex("dbo.OrderDetails", "DomainServiceOrder_ID");
            CreateIndex("dbo.OrderDetails", "HostingOrder_ID");
            CreateIndex("dbo.HostingOrders", "DomainService_ID");
            CreateIndex("dbo.HostingOrders", "User_UserID");
            AddForeignKey("dbo.OrderDetails", "DomainServiceOrder_ID", "dbo.DomainServiceOrders", "ID");
            AddForeignKey("dbo.HostingOrders", "DomainService_ID", "dbo.DomainServices", "ID");
            AddForeignKey("dbo.HostingOrders", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.OrderDetails", "HostingOrder_ID", "dbo.HostingOrders", "ID");
            DropColumn("dbo.OrderDetails", "Title");
            DropColumn("dbo.OrderDetails", "CategoryName");
            DropColumn("dbo.OrderDetails", "Product_ID");
            DropColumn("dbo.OrderDetails", "DomainService_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "DomainService_ID", c => c.Int());
            AddColumn("dbo.OrderDetails", "Product_ID", c => c.Int());
            AddColumn("dbo.OrderDetails", "CategoryName", c => c.String());
            AddColumn("dbo.OrderDetails", "Title", c => c.String());
            DropForeignKey("dbo.OrderDetails", "HostingOrder_ID", "dbo.HostingOrders");
            DropForeignKey("dbo.HostingOrders", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.HostingOrders", "DomainService_ID", "dbo.DomainServices");
            DropForeignKey("dbo.OrderDetails", "DomainServiceOrder_ID", "dbo.DomainServiceOrders");
            DropForeignKey("dbo.DomainServiceOrders", "DomainService_ID", "dbo.DomainServices");
            DropIndex("dbo.HostingOrders", new[] { "User_UserID" });
            DropIndex("dbo.HostingOrders", new[] { "DomainService_ID" });
            DropIndex("dbo.OrderDetails", new[] { "HostingOrder_ID" });
            DropIndex("dbo.OrderDetails", new[] { "DomainServiceOrder_ID" });
            DropIndex("dbo.DomainServiceOrders", new[] { "DomainService_ID" });
            DropColumn("dbo.HostingOrders", "User_UserID");
            DropColumn("dbo.HostingOrders", "DomainService_ID");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.OrderDetails", "HostingOrder_ID");
            DropColumn("dbo.OrderDetails", "DomainServiceOrder_ID");
            DropColumn("dbo.OrderDetails", "SideID");
            DropTable("dbo.DomainServiceOrders");
            CreateIndex("dbo.OrderDetails", "DomainService_ID");
            CreateIndex("dbo.OrderDetails", "Product_ID");
            AddForeignKey("dbo.OrderDetails", "DomainService_ID", "dbo.DomainServices", "ID");
            AddForeignKey("dbo.OrderDetails", "Product_ID", "dbo.Products", "ID");
        }
    }
}
