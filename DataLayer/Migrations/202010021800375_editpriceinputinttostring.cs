namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editpriceinputinttostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HostingServices", "threeMonthsCost", c => c.String());
            AlterColumn("dbo.HostingServices", "SixMonthsCost", c => c.String());
            AlterColumn("dbo.HostingServices", "AnnuallyCost", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HostingServices", "AnnuallyCost", c => c.Int(nullable: false));
            AlterColumn("dbo.HostingServices", "SixMonthsCost", c => c.Int(nullable: false));
            AlterColumn("dbo.HostingServices", "threeMonthsCost", c => c.Int(nullable: false));
        }
    }
}
