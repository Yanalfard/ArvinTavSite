namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateHostingDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HostingOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExpirationHostSide = c.Int(nullable: false),
                        DomainName = c.String(),
                        HostingService_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HostingServices", t => t.HostingService_ID)
                .Index(t => t.HostingService_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HostingOrders", "HostingService_ID", "dbo.HostingServices");
            DropIndex("dbo.HostingOrders", new[] { "HostingService_ID" });
            DropTable("dbo.HostingOrders");
        }
    }
}
