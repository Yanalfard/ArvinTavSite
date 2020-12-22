using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,PartAdmin,Content")]
    public class PackageController : Controller
    {
        private ArvinContext db = new ArvinContext();
        private IServiceCategoryRepository serviceCategoryRepository;
        private IPackageRepository packageRepository;

        public PackageController()
        {

            serviceCategoryRepository = new ServiceCategoryRepository(db);
            packageRepository = new PackageRepository(db);
        }

        // GET: Admin/Package
        public ActionResult Index(int PageId = 1, string Result = "", int InPageCount = 0)
        {
            if (Result == null)
            {
                if (InPageCount == 0)
                {
                    int count = packageRepository.AllPackageServices().Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return View();
                }
                else
                {

                    int count = packageRepository.AllPackageServices().Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return View();
                }
            }
            else
            {
                if (InPageCount == 0)
                {
                    int count = packageRepository.AllPackageServices().Where(h => h.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return View();
                }
                else
                {

                    int count = packageRepository.AllPackageServices().Where(h => h.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return View();
                }
            }
        }

        public ActionResult P_List(int PageId = 1, string Result = "", int InPageCount = 0)
        {
            if (Result == null || Result == "")
            {
                if (InPageCount == 0)
                {
                    int count = packageRepository.AllPackageServices().Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(packageRepository.AllPackageServices().OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = packageRepository.AllPackageServices().Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(packageRepository.AllPackageServices().OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                }
            }
            else
            {
                if (InPageCount == 0)
                {
                    int count = packageRepository.AllPackageServices().Where(h => h.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(packageRepository.AllPackageServices().Where(h => h.Title.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = packageRepository.AllPackageServices().Where(h => h.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(packageRepository.AllPackageServices().Where(h => h.Title.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                }
            }
        }

        public ActionResult P_Create()
        {
            return PartialView(serviceCategoryRepository.AllMainServiceCategory(true));
        }

        public ActionResult P_ChildCategoryInCreate(int ParentID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ParentID, true));
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Create(int Category, string Title, string Price, string Image, string Description)
        {
            return Json(packageRepository.Create(Category, Title, Price, Image, Description));
        }

        public JsonResult CreatePackageServiceDetails(List<PackageServiceDetails> details)
        {
            return Json(packageRepository.CreatePackageServiceDetails(details));
        }

        public ActionResult P_Edit(int ID)
        {
            PackageEditViewModel packageEditViewModel = new PackageEditViewModel();
            packageEditViewModel.AllMainServiceCatgory = serviceCategoryRepository.AllMainServiceCategory(true);
            packageEditViewModel.PackageService = packageRepository.PackageServiceById(ID);
            return PartialView(packageEditViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(int ID, int Category, string Title, string Price, string Image, string Description)
        {
            if (Image != "" || Image != null)
            {
                string fullPathImage = Request.MapPath("/Document/img/Package/" + packageRepository.PackageServiceById(ID).Image);
                if (System.IO.File.Exists(fullPathImage))
                {
                    System.IO.File.Delete(fullPathImage);
                }
            }
            return Json(packageRepository.Edit(ID, Category, Title, Price, Image, Description));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                packageRepository.Dispose();
                serviceCategoryRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}