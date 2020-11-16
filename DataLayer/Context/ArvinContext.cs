using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
    public class ArvinContext : DbContext
    {
        public DbSet<ServiceCategory> ServiceCategories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<PackageService> PackageServices { get; set; }

        public DbSet<PackageServiceDetail> packageServiceDetails { get; set; }

        public DbSet<Project> projects { get; set; }

        public DbSet<TicketCategory> TicketCategories { get; set; }

        public DbSet<Ticket> tickets { get; set; }

        public DbSet<InnerTicket> InnerTickets { get; set; }

        public DbSet<Spider> spiders { get; set; }

        public DbSet<SpiderCategory> spiderCategories { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<MarketerReport> marketerReports { get; set; }

        public DbSet<Partner> partners { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<SeoTage> seoTages { get; set; }

        public DbSet<Massage> massages { get; set; }

        public DbSet<Slider> sliders { get; set; }

        public DbSet<Discount> discounts { get; set; }


    }
}
