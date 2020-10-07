namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pckgepriceconvertinttostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PackageServices", "Price", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PackageServices", "Price", c => c.Int(nullable: false));
        }
    }
}
