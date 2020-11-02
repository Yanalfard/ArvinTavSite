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

        public IEnumerable<Ticket> AllTicketForUser(int UserID)
        {
            return db.tickets.Where(t => t.User.UserID == UserID);
        }

        public TicketListViewModel AllTicketInView()
        {
            TicketListViewModel ticketListViewModel = new TicketListViewModel();
            ticketListViewModel.ticketCategories = db.TicketCategories.Where(tc => tc.IsActive == true);
            ticketListViewModel.tickets = AllTickets();
            return ticketListViewModel;
        }

        public IEnumerable<TicketCategory> ticketCategories()
        {
            return db.TicketCategories;
        }

        public TicketCategory ticketCategoryById(int ID)
        {
            return db.TicketCategories.Find(ID);
        }

        public string SupportCreate(string Title, int IsActive)
        {
            try
            {
                TicketCategory ticketCategory = new TicketCategory();
                ticketCategory.Title = Title;
                if (IsActive == 1)
                {
                    ticketCategory.IsActive = true;
                }
                else
                {
                    ticketCategory.IsActive = false;
                }
                db.TicketCategories.Add(ticketCategory);
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public string SupportEdit(int ID, string Title, int IsActive)
        {
            try
            {
                TicketCategory ticketCategory = ticketCategoryById(ID);
                ticketCategory.Title = Title;
                if (IsActive == 1)
                {
                    ticketCategory.IsActive = true;
                }
                else
                {
                    ticketCategory.IsActive = false;
                }
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
                throw;
            }
        }

        public string RemoveSupoort(int ID)
        {
            try
            {
                IEnumerable<InnerTicket> innerTickets = db.innerTickets.Where(it => it.Ticket.TicketCategory.ID == ID);
                db.innerTickets.RemoveRange(innerTickets);
                IEnumerable<Ticket> tickets = db.tickets.Where(t => t.TicketCategory.ID == ID);
                db.tickets.RemoveRange(tickets);
                db.TicketCategories.Remove(ticketCategoryById(ID));
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
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
