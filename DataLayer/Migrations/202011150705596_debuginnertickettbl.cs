namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class debuginnertickettbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InnerTickets", "SideID", c => c.Int());
            AlterColumn("dbo.PackageServices", "Description", c => c.String(maxLength: 1000));
            DropColumn("dbo.InnerTickets", "ParentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InnerTickets", "ParentID", c => c.Int());
            AlterColumn("dbo.PackageServices", "Description", c => c.String());
            DropColumn("dbo.InnerTickets", "SideID");
        }
    }
}
