namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_DomainPriceintconverttostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DomainServices", "Price", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DomainServices", "Price", c => c.Int(nullable: false));
        }
    }
}
