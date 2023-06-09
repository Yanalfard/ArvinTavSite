﻿using System;
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

        IEnumerable<Ticket> AllTicketForUser(int UserID);

        void CreateTicketInUser(CreateTicketInUser createTicketInUser);

        InnerTicketViewModel GetInnerTicket(int ID);

        IEnumerable<TicketCategory> ticketCategories();

        TicketCategory ticketCategoryById(int ID);

        string SupportCreate(string Title, int IsActive);

        string SupportEdit(int ID, string Title, int IsActive);

        string RemoveSupoort(int ID);

        Ticket GetTicketById(int ID);

        string SendMassage(int ID, int SideID, string TextMassage, string FileMassage, int UserID);

        void Save();

    }
}
