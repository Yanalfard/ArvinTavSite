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

        public IEnumerable<Ticket> AllTickets()
        {
            return db.tickets;
        }

        public TicketListViewModel AllTicketInView()
        {
            TicketListViewModel ticketListViewModel = new TicketListViewModel();
            ticketListViewModel.ticketCategories = db.TicketCategories;
            ticketListViewModel.tickets = AllTickets();
            return ticketListViewModel;
        }

        public InnerTicketViewModel GetInnerTicket(int ID)
        {
            InnerTicketViewModel innerTicketViewModel = new InnerTicketViewModel();
            innerTicketViewModel.Ticket = GetTicketById(ID);
            innerTicketViewModel.innerTickets = db.innerTickets.Where(it => it.Ticket.ID == ID);

            return innerTicketViewModel;
        }

        public Ticket GetTicketById(int ID)
        {
            return db.tickets.Find(ID);
        }

        public IEnumerable<InnerTicket> SupporterinnerTickets(int ID)
        {
            return db.innerTickets.Where(it => it.ParentID == ID);
        }

        public string SendMassage(int ID, string TextMassage, string FileMassage)
        {
            try
            {
                InnerTicket innerTicket = new InnerTicket();
                innerTicket.dateTime = DateTime.Now;
                innerTicket.Text = TextMassage;
                if (string.IsNullOrEmpty(FileMassage))
                {
                    innerTicket.File = null;
                }
                else
                {
                    innerTicket.File = FileMassage;
                }
                InnerTicket InnerTicket = GetTicketById(ID).InnerTickets.Where(it => it.Ticket.ID == ID).OrderBy(it => it.ID).Last();
                innerTicket.ParentID = InnerTicket.ID;
                innerTicket.Ticket = GetTicketById(ID);
                //innerTicket.User =;
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}
