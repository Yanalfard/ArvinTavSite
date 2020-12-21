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
        private ArvinContext db = new ArvinContext();
        private IServiceCategoryRepository serviceCategoryRepository;
        private IUserRepository userRepository;
        private IPackageRepository packageRepository;
        private IProjectRepository projectRepository;
        private ISliderRepository sliderRepository;
        private IMassageRepository massageRepository;
        private ISpiderRepository spiderRepository;
        private IPartnerRepository partnerRepository;

        public HomeController()
        {

            serviceCategoryRepository = new ServiceCategoryRepository(db);
            userRepository = new UserRepository(db);
            packageRepository = new PackageRepository(db);
            projectRepository = new ProjectRepository(db);
            sliderRepository = new SliderRepository(db);
            massageRepository = new MassageRepository(db);
            spiderRepository = new SpiderRepository(db);
            partnerRepository = new PartnerRepository(db);
        }

        // GET: Home
        [Route("")]
        public ActionResult Index()
        {
            LandingViewModel landingView = new LandingViewModel();
            landingView.packageServices = packageRepository.AllPackageServices().OrderBy(p => p.OrderCount).Take(3);
            landingView.projects = projectRepository.Allprojects().Take(15);
            landingView.partners = partnerRepository.Allpartners().Take(15);
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

        public ActionResult P_ResultCategory(int ID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ID, true));
        }

        public ActionResult P_ResultCategoryMobile(int ID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ID, true));
        }

        [HttpGet]
        public ActionResult ContactUs(string Massage)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUs(Massage massage, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                if (GoogleRechapchaControl.ControlRechapcha(form) == "true")
                {
                    if (string.IsNullOrEmpty(massage.FullName) || string.IsNullOrEmpty(massage.PhoneNumber) || string.IsNullOrEmpty(massage.Text))
                    {
                        ViewBag.Erorr = "تمامی موارد اجباری میباشد";
                        return View();
                    }
                    else
                    {
                        massageRepository.CreateMassage(massage);
                        massageRepository.Save();
                        return Redirect("/Home/ContactUs?Massage=true");
                    }
                }
                else
                {
                    ViewBag.Erorr = "گزینه من ربات نیستم را تایید کنید";
                    return View();
                }
            }
            return View();

        }

        public ActionResult P_UserBox()
        {
            return PartialView(userRepository.UserByPhoneNumber(User.Identity.Name));
        }

        [Route("Search={Result}")]
        public ActionResult Search(string Result)
        {
            SearchViewModel searchViewModel = new SearchViewModel();
            searchViewModel.packageServices = packageRepository.AllPackageServices().Where(p => p.Title.Contains(Result)).Take(20).ToList();
            searchViewModel.spiders = spiderRepository.AllSpider().Where(p => p.Title.Contains(Result)).Take(20).ToList();
            return View(searchViewModel);
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