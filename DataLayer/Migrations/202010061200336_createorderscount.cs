namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createorderscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DomainServices", "OrderCount", c => c.Int(nullable: false));
            AddColumn("dbo.HostingServices", "OrderCount", c => c.Int(nullable: false));
            AddColumn("dbo.PackageServices", "OrderCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PackageServices", "OrderCount");
            DropColumn("dbo.HostingServices", "OrderCount");
            DropColumn("dbo.DomainServices", "OrderCount");
        }
    }
}
