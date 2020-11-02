using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,PartAdmin,Marketer,Content")]
    public class DashboardController : Controller
    {
        private ArvinContext db = new ArvinContext();
        private IStatisticRepository statisticRepository;
        private IUserRepository userRepository;
        private ITicketRepository ticketRepository;
        private IOrderRepository orderRepository;

        public DashboardController()
        {
            statisticRepository = new StatisticRepository(db);
            userRepository = new UserRepository(db);
            ticketRepository = new TicketRepository(db);
            orderRepository = new OrderRepository(db);
        }

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View(statisticRepository.Allstatistic());
        }

        public ActionResult P_UserBox()
        {
            return PartialView(userRepository.UserByPhoneNumber(User.Identity.Name));
        }

        public ActionResult notification()
        {
            return PartialView(ticketRepository.AllTickets().Where(t => t.Status == 1));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                statisticRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}