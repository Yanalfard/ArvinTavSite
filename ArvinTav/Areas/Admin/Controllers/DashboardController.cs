using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private IServiceCategoryRepository serviceCategoryRepository;
        private IDomainRepository domainRepository;
        private IHostingRepository HostingRepository;
        private IPackageRepository packageRepository;
        private IUserRepository userRepository;
        private IOrderRepository orderRepository;
        private ITicketRepository ticketRepository;
        private ArvinContext db = new ArvinContext();

        public DashboardController()
        {
            serviceCategoryRepository = new ServiceCategoryRepository(db);
            domainRepository = new DomainRepository(db);
            HostingRepository = new HostingRepository(db);
            packageRepository = new PackageRepository(db);
            userRepository = new UserRepository(db);
            orderRepository = new OrderRepository(db);
            ticketRepository = new TicketRepository(db);
        }

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            ViewBag.User = userRepository.AllUser().Where(u => u.UserRole.Name == "User").Count();
            ViewBag.Personnel = userRepository.AllUser().Where(u => u.UserRole.Name == "Content" || u.UserRole.Name == "Marketer" || u.UserRole.Name == "Manager" || u.UserRole.Name == "Admin").Count();
            ViewBag.Host = HostingRepository.AllhostingServices().Count();
            ViewBag.Domain = domainRepository.AllDomain(false).Count();
            ViewBag.Package = packageRepository.AllPackageServices().Count();
            ViewBag.Order = orderRepository.AllOrders().Count();
            ViewBag.Ticket = ticketRepository.AllTicketInView().tickets.Count();
            ViewBag.TicketEnded = ticketRepository.AllTicketInView().tickets.Where(t => t.Status == 4).Count();
            ViewBag.TicketNotSeen = ticketRepository.AllTicketInView().tickets.Where(t => t.Status == 1).Count();
            return View();
        }
    }
}