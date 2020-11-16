namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editmassagetbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Massages", "FullName", c => c.String(maxLength: 100));
            AddColumn("dbo.Massages", "Email", c => c.String(maxLength: 100));
            AddColumn("dbo.Massages", "PhoneNumber", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Massages", "PhoneNumber");
            DropColumn("dbo.Massages", "Email");
            DropColumn("dbo.Massages", "FullName");
        }
    }
}
