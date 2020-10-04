namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "dateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "dateTime");
        }
    }
}
