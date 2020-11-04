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
        private IProductRepository productRepository;
        private IHostingRepository hostingRepository;
        private IDomainRepository domainRepository;

        public HomeController()
        {
            serviceCategoryRepository = new ServiceCategoryRepository(db);
            productRepository = new ProductRepository(db);
            hostingRepository = new HostingRepository(db);
            domainRepository = new DomainRepository(db);
        }

        // GET: Home
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        //
        //Start Partial Category
        public ActionResult P_MainCategory()
        {
            return PartialView(serviceCategoryRepository.AllMainServiceCategory(true));
        }

        public ActionResult P_ChildCategory(int ID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ID, true).ChildCategories);
        }

        public ActionResult P_SubCategory(int ID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ID, true).ChildCategories);
        }
        //End Partial Category
        //
        [Route("Category/{ID}")]
        public ActionResult Category(int ID)
        {
            ChildCategoryINViewViewmodel childCategoryINViewViewmodel = new ChildCategoryINViewViewmodel();
            childCategoryINViewViewmodel.ServiceCategory = serviceCategoryRepository.ServiceCategoryById(ID);
            childCategoryINViewViewmodel.serviceCategories = serviceCategoryRepository.AllChildCategory(ID, true).ChildCategories;
            return View(childCategoryINViewViewmodel);
        }

        [Route("Products/{ID}")]
        public ActionResult Products(int ID)
        {
            return View(productRepository.AllProduct().Where(p => p.ServiceCategory.ID == ID));
        }

        [Route("Product/{ID}")]
        public ActionResult Product(int ID)
        {
            return View(productRepository.productById(ID));
        }

        [Route("SubmitDomain/{HostingServiceID}/{PeriodOfService}")]
        public ActionResult SubmitDomain(int HostingServiceID, int PeriodOfService)
        {
            SubmitDomainViewModel submitDomainViewModel = new SubmitDomainViewModel();

            submitDomainViewModel.HostingService = hostingRepository.HostingServiceById(HostingServiceID);
            submitDomainViewModel.PeriodOfService = PeriodOfService;
            submitDomainViewModel.domainServices = domainRepository.AllDomain(true);
            return View(submitDomainViewModel);
        }
    }
}