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
        public DbSet<DomainService> DomainServices { get; set; }

        public DbSet<HostingService> HostingServices { get; set; }

        public DbSet<HostingServiceDetails> HostingServiceDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<PackageService> PackageServices { get; set; }

        public DbSet<ServiceCategory> ServiceCategories { get; set; }

        public DbSet<TicketCategory> TicketCategories { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }


    }
}
