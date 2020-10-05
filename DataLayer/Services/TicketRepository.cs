using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TicketRepository : ITicketRepository
    {
        private ArvinContext db;

        public TicketRepository(ArvinContext context)
        {
            this.db = context;
        }
        public IEnumerable<Ticket> AllTicket()
        {
            return db.tickets;
        }
    }
}
