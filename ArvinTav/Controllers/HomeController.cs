using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Controllers
{
    public class HomeController : Controller
    {
        private IDatabase database;
        private IServiceCategoryRepository serviceCategoryRepository;
        private IUserRepository userRepository;
        private IPackageRepository packageRepository;
        private IProjectRepository projectRepository;
        private ISliderRepository sliderRepository;

        public HomeController()
        {
            this.database = new Database();
            serviceCategoryRepository = new ServiceCategoryRepository(database._db());
            userRepository = new UserRepository(database._db());
            packageRepository = new PackageRepository(database._db());
            projectRepository = new ProjectRepository(database._db());
            sliderRepository = new SliderRepository(database._db());
        }

        // GET: Home
        [Route("")]
        public ActionResult Index()
        {
            LandingViewModel landingView = new LandingViewModel();
            landingView.packageServices = packageRepository.AllPackageServices().OrderBy(p => p.OrderCount).Take(3);
            landingView.projects = projectRepository.Allprojects().Take(15);
            landingView.AllSlider = sliderRepository.AllSliders();
            return View(landingView);
        }


        //Start Partial Category
        public ActionResult P_MainCategory()
        {
            return PartialView(serviceCategoryRepository.AllMainServiceCategory(true));
        }

        public ActionResult P_MainCategoryMobile()
        {
            return PartialView(serviceCategoryRepository.AllMainServiceCategory(true));
        }

        public ActionResult P_ChildCategory(int ID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ID, true).ChildCategories);
        }

        public ActionResult P_ChildCategoryMobile(int ID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ID, true).ChildCategories);
        }

        public ActionResult P_SubCategoryMobile(int ID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ID, true).ChildCategories);
        }

        public ActionResult P_SubCategory(int ID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ID, true).ChildCategories);
        }

        [Route("AboutUs")]
        public ActionResult AboutUs()
        {
            return View();
        }

        [Route("ContactUs")]
        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(Massage massage)
        {
            var t = massage;
            return View();
        }

        public ActionResult P_UserBox()
        {
            return PartialView(userRepository.UserByPhoneNumber(User.Identity.Name));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                serviceCategoryRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}