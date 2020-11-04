using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.User.Controllers
{
    [Authorize(Roles = "Admin,PartAdmin,Marketer,Content,Customer")]
    public class TicketController : Controller
    {
        private ArvinContext db = new ArvinContext();

        private ITicketRepository ticketRepository;
        private IOrderRepository orderRepository;
        private IUserRepository userRepository;
        public TicketController()
        {
            ticketRepository = new TicketRepository(db);
            orderRepository = new OrderRepository(db);
            userRepository = new UserRepository(db);
        }

        // GET: User/Ticket
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult P_List()
        {
            return PartialView();
        }

        public ActionResult P_InnerTicket()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TicketCategory = ticketRepository.ticketCategories().Where(t => t.IsActive == true);
            ViewBag.OrderDetails = orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Select(o => o.OrderDetails);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTicketInUser createTicketInUser, HttpPostedFileBase File)
        {
            ViewBag.TicketCategory = ticketRepository.ticketCategories().Where(t => t.IsActive == true);
            ViewBag.OrderDetails = orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Select(o => o.OrderDetails);
            return View();
        }
    }
}