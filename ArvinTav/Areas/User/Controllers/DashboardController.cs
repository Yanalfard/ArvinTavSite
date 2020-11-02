using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.User.Controllers
{
    [Authorize(Roles = "Admin,PartAdmin,Marketer,Content,Customer")]
    public class DashboardController : Controller
    {
        private ArvinContext db = new ArvinContext();
        private IUserRepository userRepository;

        public DashboardController()
        {
            userRepository = new UserRepository(db);
        }

        // GET: User/Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            return View();
        }

        public ActionResult P_UserBox()
        {
            return PartialView(userRepository.UserByPhoneNumber(User.Identity.Name));
        }


    }
}