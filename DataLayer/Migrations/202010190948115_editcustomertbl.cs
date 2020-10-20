namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editcustomertbl : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Revenues", newName: "Customers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Customers", newName: "Revenues");
        }
    }
}
