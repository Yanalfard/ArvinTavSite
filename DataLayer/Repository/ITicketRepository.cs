using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ITicketRepository : IDisposable
    {
        IEnumerable<Ticket> AllTickets();

        TicketListViewModel AllTicketInView();

        InnerTicketViewModel GetInnerTicket(int ID);

        Ticket GetTicketById(int ID);

        IEnumerable<InnerTicket> SupporterinnerTickets(int ID);

        string SendMassage(int ID, string TextMassage, string FileMassage);

        void Save();

    }
}
