using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,PartAdmin,Content")]
    public class HostingController : Controller
    {

        private ArvinContext db = new ArvinContext();
        private IServiceCategoryRepository serviceCategoryRepository;
        private IHostingRepository hostingRepository;
        public HostingController()
        {
            serviceCategoryRepository = new ServiceCategoryRepository(db);
            hostingRepository = new HostingRepository(db);
        }
        // GET: Admin/Hosting
        public ActionResult Index(int PageId = 1, string Result = "", int InPageCount = 0)
        {
            if (Result == null)
            {
                if (InPageCount == 0)
                {
                    int count = hostingRepository.AllhostingServices().Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return View();
                }
                else
                {

                    int count = hostingRepository.AllhostingServices().Count();

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
                    int count = hostingRepository.AllhostingServices().Where(h => h.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return View();
                }
                else
                {

                    int count = hostingRepository.AllhostingServices().Where(h => h.Title.Contains(Result)).Count();

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
                    int count = hostingRepository.AllhostingServices().Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(hostingRepository.AllhostingServices().OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = hostingRepository.AllhostingServices().Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(hostingRepository.AllhostingServices().OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                }
            }
            else
            {
                if (InPageCount == 0)
                {
                    int count = hostingRepository.AllhostingServices().Where(h => h.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(hostingRepository.AllhostingServices().Where(h => h.Title.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = hostingRepository.AllhostingServices().Where(h => h.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(hostingRepository.AllhostingServices().Where(h => h.Title.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                }
            }

        }

        public ActionResult P_Create()
        {
            return PartialView(serviceCategoryRepository.AllMainServiceCategory(true));
        }

        public int Create(int Category, string Title, int FreeSSL, int Support, string Space, string MonthlyTraffic, string SitesBeHosted, string threeMonthsCost, string SixMonthsCost, string AnnuallyCost)
        {
            return hostingRepository.Create(Category, Title, FreeSSL, Support, Space, MonthlyTraffic, SitesBeHosted, threeMonthsCost, SixMonthsCost, AnnuallyCost);
        }

        public JsonResult CreateHostingServiceDetails(List<HostingServiceDetailsViewModel> Details)
        {
            return Json(hostingRepository.CreateHostingServiceDetails(Details));
        }

        public ActionResult P_Edit(int ID)
        {
            return PartialView(hostingRepository.hostingEditViewModel(ID));
        }

        public int Edit(int ID, int Category, string Title, int FreeSSL, int Support, string Space, string MonthlyTraffic, string SitesBeHosted, string threeMonthsCost, string SixMonthsCost, string AnnuallyCost)
        {
            return hostingRepository.Edit(ID, Category, Title, FreeSSL, Support, Space, MonthlyTraffic, SitesBeHosted, threeMonthsCost, SixMonthsCost, AnnuallyCost);
        }
        public ActionResult P_Remove(int ID)
        {
            return PartialView(hostingRepository.HostingServiceById(ID));
        }

        public string Remove(int ID)
        {
            return hostingRepository.Remove(ID);
        }

        public ActionResult P_HostingDetails(int ID)
        {
            return PartialView(hostingRepository.AllHostingDetails(ID));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                hostingRepository.Dispose();
                serviceCategoryRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}