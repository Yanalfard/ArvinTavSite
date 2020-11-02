using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.User.Controllers
{
    [Authorize(Roles = "Admin,PartAdmin,Marketer,Content,Customer")]
    public class OrderController : Controller
    {
        private ArvinContext db = new ArvinContext();
        private IOrderRepository orderRepository;
        private IUserRepository userRepository;

        public OrderController()
        {
            orderRepository = new OrderRepository(db);
            userRepository = new UserRepository(db);
        }

        // GET: User/Order
        public ActionResult Index()
        {
            return View(orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID));
        }

        public ActionResult P_List()
        {
            return PartialView();
        }
    }
}