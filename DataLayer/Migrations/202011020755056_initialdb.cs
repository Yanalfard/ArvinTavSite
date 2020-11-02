namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(maxLength: 100));
            AlterColumn("dbo.Discounts", "Code", c => c.String(maxLength: 100));
            AlterColumn("dbo.DomainServiceOrders", "DomainName", c => c.String(maxLength: 200));
            AlterColumn("dbo.DomainServices", "Suffix", c => c.String(maxLength: 10));
            AlterColumn("dbo.ServiceCategories", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.ServiceCategories", "Description", c => c.String(maxLength: 600));
            AlterColumn("dbo.HostingServices", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.HostingServices", "Space", c => c.String(maxLength: 100));
            AlterColumn("dbo.HostingServices", "Monthly_Traffic", c => c.String(maxLength: 100));
            AlterColumn("dbo.HostingServices", "Sites_Be_Hosted", c => c.String(maxLength: 100));
            AlterColumn("dbo.HostingOrders", "DomainName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Tickets", "Subject", c => c.String(maxLength: 500));
            AlterColumn("dbo.Orders", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.PackageServices", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.PackageServices", "Description", c => c.String(maxLength: 600));
            AlterColumn("dbo.TicketCategories", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.MarketerReports", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.MarketerReports", "Description", c => c.String(maxLength: 600));
            AlterColumn("dbo.HostingServiceDetails", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.HostingServiceDetails", "Response", c => c.String(maxLength: 100));
            AlterColumn("dbo.Spiders", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Spiders", "Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.Partners", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Partners", "PhoneNumber", c => c.String(maxLength: 15));
            AlterColumn("dbo.Projects", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Projects", "Link", c => c.String(maxLength: 900));
            AlterColumn("dbo.Sliders", "Title", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sliders", "Title", c => c.String());
            AlterColumn("dbo.Projects", "Link", c => c.String());
            AlterColumn("dbo.Projects", "Title", c => c.String());
            AlterColumn("dbo.Partners", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Partners", "Title", c => c.String());
            AlterColumn("dbo.Spiders", "Description", c => c.String());
            AlterColumn("dbo.Spiders", "Title", c => c.String());
            AlterColumn("dbo.HostingServiceDetails", "Response", c => c.String());
            AlterColumn("dbo.HostingServiceDetails", "Title", c => c.String());
            AlterColumn("dbo.MarketerReports", "Description", c => c.String());
            AlterColumn("dbo.MarketerReports", "Title", c => c.String());
            AlterColumn("dbo.TicketCategories", "Title", c => c.String());
            AlterColumn("dbo.PackageServices", "Description", c => c.String());
            AlterColumn("dbo.PackageServices", "Title", c => c.String());
            AlterColumn("dbo.Orders", "Price", c => c.String());
            AlterColumn("dbo.Tickets", "Subject", c => c.String());
            AlterColumn("dbo.HostingOrders", "DomainName", c => c.String());
            AlterColumn("dbo.HostingServices", "Sites_Be_Hosted", c => c.String());
            AlterColumn("dbo.HostingServices", "Monthly_Traffic", c => c.String());
            AlterColumn("dbo.HostingServices", "Space", c => c.String());
            AlterColumn("dbo.HostingServices", "Title", c => c.String());
            AlterColumn("dbo.ServiceCategories", "Description", c => c.String());
            AlterColumn("dbo.ServiceCategories", "Title", c => c.String());
            AlterColumn("dbo.DomainServices", "Suffix", c => c.String());
            AlterColumn("dbo.DomainServiceOrders", "DomainName", c => c.String());
            AlterColumn("dbo.Discounts", "Code", c => c.String());
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Customers", "Title", c => c.String());
        }
    }
}
