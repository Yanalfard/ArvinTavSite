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
        public HomeController()
        {
            serviceCategoryRepository = new ServiceCategoryRepository(db);
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

        [Route("Products/{ID?}")]
        public ActionResult Products(int? ID)
        {
            return View();
        }

        [Route("Product/{ID?}")]
        public ActionResult Product(int? ID)
        {
            return View();
        }

    }
}