namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class debugmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(maxLength: 11));
            AlterColumn("dbo.Discounts", "Code", c => c.String(maxLength: 30));
            AlterColumn("dbo.InnerTickets", "Text", c => c.String(maxLength: 200));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 80));
            AlterColumn("dbo.UserRoles", "Title", c => c.String(maxLength: 20));
            AlterColumn("dbo.UserRoles", "Name", c => c.String(maxLength: 20));
            AlterColumn("dbo.SeoTages", "Tage", c => c.String(maxLength: 20));
            AlterColumn("dbo.Partners", "PhoneNumber", c => c.String(maxLength: 11));
            AlterColumn("dbo.Sliders", "Link", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sliders", "Link", c => c.String());
            AlterColumn("dbo.Partners", "PhoneNumber", c => c.String(maxLength: 15));
            AlterColumn("dbo.SeoTages", "Tage", c => c.String());
            AlterColumn("dbo.UserRoles", "Name", c => c.String());
            AlterColumn("dbo.UserRoles", "Title", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.InnerTickets", "Text", c => c.String());
            AlterColumn("dbo.Discounts", "Code", c => c.String(maxLength: 100));
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(maxLength: 100));
            AlterColumn("dbo.Customers", "Title", c => c.String(maxLength: 100));
        }
    }
}
