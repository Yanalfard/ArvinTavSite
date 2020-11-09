using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLaye;
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
            return View(userRepository.UserByPhoneNumber(User.Identity.Name));
        }

        public ActionResult MyProfile()
        {
            DataLayer.User user = userRepository.UserByPhoneNumber(User.Identity.Name);
            FullRegsiterViewModel fullRegsiterViewModel = new FullRegsiterViewModel();
            fullRegsiterViewModel.FullName = user.FullName;
            fullRegsiterViewModel.Brand = user.Brand;
            fullRegsiterViewModel.Email = user.Email;
            fullRegsiterViewModel.Image = user.Image;
            return View(fullRegsiterViewModel);
        }

        public ActionResult P_UserBox()
        {
            return PartialView(userRepository.UserByPhoneNumber(User.Identity.Name));
        }


    }
}