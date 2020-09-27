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
            return View(serviceCategoryRepository.AllMainServiceCategory(false));
        }
        public ActionResult P_ChildCategory(int ParentID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ParentID, false));
        }

        public ActionResult P_Create(int ParentID)
        {
            ViewBag.ParentID = ParentID;
            return PartialView();
        }

        [ValidateInput(false)]
        public JsonResult Create(int? ParentID, string Title, bool? IsActive, string Description, string Image)
        {
            return Json(serviceCategoryRepository.AddServiceCategory(ParentID.Value, Title, IsActive.Value, Description, Image));
        }

        public ActionResult P_Edit(int ID)
        {
            return PartialView(serviceCategoryRepository.ServiceCategoryById(ID));
        }

        [ValidateInput(false)]
        public JsonResult Edit(int ID,int? ParentID, string Title, bool? IsActive, string Description, string Image)
        {
            return Json(serviceCategoryRepository.EditServiceCategory(ID, Title, IsActive.Value, Description, Image));
        }

        public ActionResult P_Remove(int ID)
        {
            return PartialView(serviceCategoryRepository.ServiceCategoryById(ID));
        }

        public string Remove(int ID)
        {
            return "true";
        }
    }
}