using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StatisticRepository : IStatisticRepository
    {
        private ArvinContext db;
        private IOrderRepository orderRepository;
        private ITicketRepository ticketRepository;
        private IUserRepository userRepository;
        private IHostingRepository hostingRepository;
        private IDomainRepository domainRepository;
        private IPackageRepository packageRepository;

        public StatisticRepository(ArvinContext context)
        {
            this.db = context;
            orderRepository = new OrderRepository(db);
            ticketRepository = new TicketRepository(db);
            userRepository = new UserRepository(db);
            hostingRepository = new HostingRepository(db);
            domainRepository = new DomainRepository(db);
            packageRepository = new PackageRepository(db);

        }

        public StatisticViewModel Allstatistic()
        {
            StatisticViewModel statisticViewModel = new StatisticViewModel();
            statisticViewModel.AllUserCount = userRepository.AllUser().Where(u => u.UserRole.RoleID == 5).Count();
            statisticViewModel.AllPersonnelCount = userRepository.AllUser().Where(u => u.UserRole.RoleID < 5).Count();
            statisticViewModel.AllHostingCount = hostingRepository.AllhostingServices().Count();
            statisticViewModel.AllDomainCount = domainRepository.AllDomain(false).Count();
            statisticViewModel.AllPackageCount = packageRepository.AllPackageServices().Count();
            statisticViewModel.AllOrderCount = orderRepository.AllOrders().Count();
            statisticViewModel.AllTicket = ticketRepository.AllTickets().Count();
            statisticViewModel.TicketNotSeen = ticketRepository.AllTickets().Where(t => t.Status == 1).Count();
            statisticViewModel.TicketEnded = ticketRepository.AllTickets().Where(t => t.Status == 3).Count();
            return statisticViewModel;
        }

        public RevenuesViewModel AllRevenues()
        {
            RevenuesViewModel revenuesViewModel = new RevenuesViewModel();

            List<string> pricesString = new List<string>();
            db.Orders.Where(o => o.Status == 2).ToList().ForEach(p => pricesString.Add(p.Price));
            List<int> prices = new List<int>();
            pricesString.ForEach(p => prices.Add(Convert.ToInt32(p.Replace(",", ""))));
            revenuesViewModel.AllPaidPrice = prices.Sum().ToString();

            ///////////////////////

            List<string> CancelledpricesString = new List<string>();
            db.Orders.Where(o => o.Status == 4).ToList().ForEach(p => CancelledpricesString.Add(p.Price));
            List<int> Cancelledprices = new List<int>();
            CancelledpricesString.ForEach(p => Cancelledprices.Add(Convert.ToInt32(p.Replace(",", ""))));
            revenuesViewModel.AllCancelledPrice = Cancelledprices.Sum().ToString();

            ///////////////////////

            revenuesViewModel.OrderCount = orderRepository.AllOrders().Count();


            return revenuesViewModel;
        }

        public OrderExplorerViewModel AllOrderExplorer()
        {
            IEnumerable<Order> AllOrder = orderRepository.AllOrders();
            OrderExplorerViewModel orderExplorer = new OrderExplorerViewModel();
            orderExplorer.AllOrderCount = orderRepository.AllOrders().Count();
            orderExplorer.AllWaitingPayOrderCount = AllOrder.Where(o => o.Status == 1).Count();
            orderExplorer.AllPaidOrderCount = AllOrder.Where(o => o.Status == 2).Count();
            orderExplorer.AllNotEndedOrderCount = AllOrder.Where(o => o.Status == 4).Count();
            orderExplorer.AllEndedOrderCount = AllOrder.Where(o => o.Status == 3).Count();
            return orderExplorer;
        }

        public TicketExplorerViewModel TicketExplorer()
        {
            IEnumerable<Ticket> AllTicket = ticketRepository.AllTickets();
            TicketExplorerViewModel ticketExplorer = new TicketExplorerViewModel();
            ticketExplorer.TicketNotSeenCount = AllTicket.Where(t => t.Status == 1).Count();
            ticketExplorer.TicketSeenCount = AllTicket.Where(t => t.Status == 2).Count();
            ticketExplorer.TicketEndedCount = AllTicket.Where(t => t.Status == 3).Count();

            return ticketExplorer;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
