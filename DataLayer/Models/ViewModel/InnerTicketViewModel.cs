using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class InnerTicketViewModel
    {
        public Ticket Ticket { get; set; }

        public IEnumerable<InnerTicket> innerTickets { get; set; }
    }
}
