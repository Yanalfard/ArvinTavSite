namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialnulabledordercount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DomainServices", "OrderCount", c => c.Int());
            AlterColumn("dbo.HostingServices", "OrderCount", c => c.Int());
            AlterColumn("dbo.PackageServices", "OrderCount", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PackageServices", "OrderCount", c => c.Int(nullable: false));
            AlterColumn("dbo.HostingServices", "OrderCount", c => c.Int(nullable: false));
            AlterColumn("dbo.DomainServices", "OrderCount", c => c.Int(nullable: false));
        }
    }
}
