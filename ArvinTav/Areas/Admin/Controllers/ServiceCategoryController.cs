using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    public class ServiceCategoryController : Controller
    {
        private IServiceCategoryRepository serviceCategoryRepository;
        private ArvinContext db = new ArvinContext();
        public ServiceCategoryController()
        {
            serviceCategoryRepository = new ServiceCategoryRepository(db);
        }
        // GET: Admin/ServiceCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult P_ChildCategory(int ParentID)
        {
            return PartialView();
        }

        public ActionResult P_Create()
        {
            return PartialView();
        }

        public string Create()
        {
            return "true";
        }

        public ActionResult P_Edit()
        {
            return PartialView();
        }

        public string Edit()
        {
            return "true";
        }

        public ActionResult P_Remove()
        {
            return PartialView();
        }

        public string Remove()
        {
            return "true";
        }
    }
}