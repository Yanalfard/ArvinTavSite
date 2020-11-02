using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StatisticViewModel
    {
        public int AllUserCount { get; set; }

        public int AllPersonnelCount { get; set; }

        public int AllHostingCount { get; set; }

        public int AllDomainCount { get; set; }

        public int AllPackageCount { get; set; }

        public int AllOrderCount { get; set; }

        public int AllTicket { get; set; }

        public int TicketEnded { get; set; }

        public int TicketNotSeen { get; set; }

        public IEnumerable<Order> OrderMonth { get; set; }

        public IEnumerable<Order> OrderCount { get; set; }

    }
}
