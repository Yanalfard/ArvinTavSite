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
        [Route("Category/{ID}")]
        public ActionResult Category(int ID)
        {
            ChildCategoryINViewViewmodel childCategoryINViewViewmodel = new ChildCategoryINViewViewmodel();
            childCategoryINViewViewmodel.ServiceCategory = serviceCategoryRepository.ServiceCategoryById(ID);
            childCategoryINViewViewmodel.serviceCategories = serviceCategoryRepository.AllChildCategory(ID, true).ChildCategories;
            return View(childCategoryINViewViewmodel);
        }
        
    }
}