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
        private IPackageRepository packageRepository;
        private IUserRepository userRepository;

        public TicketRepository(ArvinContext context)
        {
            this.db = context;
            packageRepository = new PackageRepository(db);
            userRepository = new UserRepository(db);
        }

        public IEnumerable<Ticket> AllTickets()
        {
            return db.tickets;
        }

        public IEnumerable<Ticket> AllTicketForUser(int UserID)
        {
            return db.tickets.Where(t => t.User.UserID == UserID);
        }

        public void CreateTicketInUser(CreateTicketInUser createTicketInUser)
        {
            Ticket ticket = new Ticket();
            ticket.dateTime = DateTime.Now;
            ticket.Status = 1;
            ticket.Subject = createTicketInUser.Subject;
            ticket.PackageService = packageRepository.PackageServiceById(createTicketInUser.order);
            ticket.Supporter = null;
            ticket.EndTicketTime = DateTime.Now;
            ticket.TicketCategory = ticketCategoryById(createTicketInUser.TicketCategory);
            ticket.User = createTicketInUser.user;
            db.tickets.Add(ticket);
            InnerTicket inner = new InnerTicket();
            inner.ParentID = null;
            inner.Text = createTicketInUser.Text;
            inner.Ticket = ticket;
            inner.User = createTicketInUser.user;
            inner.dateTime = DateTime.Now;
            inner.File = createTicketInUser.File;
            db.InnerTickets.Add(inner);
            Save();
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
                IEnumerable<InnerTicket> innerTickets = db.InnerTickets.Where(it => it.Ticket.TicketCategory.ID == ID);
                db.InnerTickets.RemoveRange(innerTickets);
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
            innerTicketViewModel.innerTickets = db.InnerTickets.Where(it => it.Ticket.ID == ID);

            return innerTicketViewModel;
        }

        public Ticket GetTicketById(int ID)
        {
            return db.tickets.Find(ID);
        }

        public IEnumerable<InnerTicket> SupporterinnerTickets(int ID)
        {
            return db.InnerTickets.Where(it => it.ParentID == ID);
        }

        public string SendMassage(int ID, string TextMassage, string FileMassage, int UserID)
        {
            try
            {
                InnerTicket innerTicket = new InnerTicket();
                innerTicket.dateTime = DateTime.Now;
                innerTicket.User = userRepository.UserById(UserID);
                innerTicket.Text = TextMassage;
                if (FileMassage != null)
                {
                    innerTicket.File = FileMassage;
                }
                else
                {
                    innerTicket.File = null;
                }
                innerTicket.Ticket = GetTicketById(ID);

                db.InnerTickets.Add(innerTicket);
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
