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
        public ActionResult Index(int PageId = 1, int InPageCount = 0)
        {
            if (InPageCount == 0)
            {
                int count = serviceCategoryRepository.AllMainServiceCategory(false).Count();

                var skip = (PageId - 1) * 18;

                ViewBag.pageid = PageId;

                ViewBag.PageCount = count / 18;

                ViewBag.InPageCount = InPageCount;

                return PartialView(serviceCategoryRepository.AllMainServiceCategory(false).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
            }
            else
            {

                int count = serviceCategoryRepository.AllMainServiceCategory(false).Count();

                var skip = (PageId - 1) * InPageCount;

                ViewBag.pageid = PageId;

                ViewBag.PageCount = count / InPageCount;

                ViewBag.InPageCount = InPageCount;

                return PartialView(serviceCategoryRepository.AllMainServiceCategory(false).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
            }
        }

        public ActionResult P_ChildCategory(int ParentID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ParentID, false));
        }

        public ActionResult P_ChildCategoryInCreate(int ParentID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ParentID, true));
        }

        public ActionResult P_Create(int ParentID)
        {
            ViewBag.ParentID = ParentID;
            if (ParentID != 0)
            {
                ViewBag.ParentTitle = serviceCategoryRepository.ServiceCategoryById(ParentID).Title;
            }
            else
            {
                ViewBag.ParentTitle = "اصلی";
            }
            return PartialView();
        }

        [ValidateInput(false)]
        public JsonResult Create(int ParentID, string Title, int IsActive, string Description, string Image)
        {
            return Json(serviceCategoryRepository.AddServiceCategory(ParentID, Title, IsActive, Description, Image));
        }

        public ActionResult P_Edit(int ID)
        {
            ViewBag.ParentID = serviceCategoryRepository.ServiceCategoryById(ID).ParentID;
            return PartialView(serviceCategoryRepository.ServiceCategoryById(ID));
        }

        [ValidateInput(false)]
        public JsonResult Edit(int? ID, int? ParentID, string Title, int IsActive, string Description, string Image)
        {
            if (Image != null || Image != "")
            {
                string fullPathImage = Request.MapPath("/Document/img/Category/" + serviceCategoryRepository.ServiceCategoryById(ID.Value).Image);
                if (System.IO.File.Exists(fullPathImage))
                {
                    System.IO.File.Delete(fullPathImage);
                }
            }
            return Json(serviceCategoryRepository.EditServiceCategory(ID.Value, Title, IsActive, Description, Image));
        }

        public ActionResult P_Remove(int ID)
        {
            return PartialView(serviceCategoryRepository.ServiceCategoryById(ID));
        }

        public ActionResult IsActive(int ID)
        {
            serviceCategoryRepository.IsActive(ID);
            return RedirectToAction("Index");
        }

        public string Remove(int ID)
        {
            string fullPathImage = Request.MapPath("/Document/img/Category/" + serviceCategoryRepository.ServiceCategoryById(ID).Image);

            if (System.IO.File.Exists(fullPathImage))
            {
                System.IO.File.Delete(fullPathImage);
            }

            return serviceCategoryRepository.RemoveServiceCategory(ID);
        }
    }
}