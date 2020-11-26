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
        public ActionResult Index(int PageId = 1, int Result = 0, int InPageCount = 0)
        {
            if (Result == 0)
            {
                if (InPageCount == 0)
                {
                    int count = orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.PageId = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return View();
                }
                else
                {

                    int count = orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.PageId = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return View();
                }
            }
            else
            {
                if (InPageCount == 0)
                {
                    int count = orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Where(o => o.ID == Result).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.PageId = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return View();
                }
                else
                {

                    int count = orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Where(o => o.ID == Result).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.PageId = PageId;

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return View();
                }
            }
        }

        public ActionResult P_List(int PageId = 1, int Result = 0, int InPageCount = 0)
        {
            if (Result == 0)
            {
                if (InPageCount == 0)
                {
                    int count = orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.PageId = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.PageId = PageId;

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).ToList());
                }
            }
            else
            {
                if (InPageCount == 0)
                {
                    int count = orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Where(o => o.ID == Result).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.PageId = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Where(o => o.ID == Result).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Where(o => o.ID == Result).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.PageId = PageId;

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(orderRepository.AllOrderForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Where(o => o.ID == Result).ToList());
                }
            }
        }

        public ActionResult P_Detail(int ID)
        {
            return PartialView(orderRepository.OrderById(ID));
        }
    }
}