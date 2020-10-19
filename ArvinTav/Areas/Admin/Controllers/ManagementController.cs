using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    public class ManagementController : Controller
    {
        private ISpiderRepository spiderRepository;
        private IMarketerRepository marketerRepository;
        private ArvinContext db = new ArvinContext();

        public ManagementController()
        {
            spiderRepository = new SpiderRepository(db);
            marketerRepository = new MarketerRepository(db);
        }

        // GET: Admin/Management
        public ActionResult Index()
        {
            return View();
        }


        /// <شروع اسپایدر>
        /// ///////////////////////////////////Spider


        public ActionResult P_Spider(int PageId = 1, string Result = "", int InPageCount = 0)
        {
            if (Result == "")
            {
                if (InPageCount == 0)
                {
                    int count = spiderRepository.AllSpider().Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(spiderRepository.AllSpider().OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = spiderRepository.AllSpider().Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(spiderRepository.AllSpider().OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                }
            }
            else
            {
                if (InPageCount == 0)
                {
                    int count = spiderRepository.AllSpider().Where(s => s.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(spiderRepository.AllSpider().Where(s => s.Title.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = spiderRepository.AllSpider().Where(s => s.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(spiderRepository.AllSpider().Where(s => s.Title.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                }
            }
        }

        public ActionResult P_SpiderCreate()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SpiderCreate(string Title, string Description, string Image, List<string> SeoTages)
        {
            return Json(spiderRepository.AddSpider(Title, Description, Image, SeoTages));
        }

        public ActionResult P_SpiderEdit(int ID)
        {
            return PartialView(spiderRepository.SpiderById(ID));
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SpiderEdit(int ID, string Title, string Description, string Image, List<string> SeoTages)
        {
            if (Image != null || Image != "")
            {
                string fullPathImage = Request.MapPath("/Document/img/Spider/" + spiderRepository.SpiderById(ID).Image);
                if (System.IO.File.Exists(fullPathImage))
                {
                    System.IO.File.Delete(fullPathImage);
                }
            }
            return Json(spiderRepository.SpiderEdit(ID, Title, Description, Image, SeoTages));
        }

        public ActionResult P_SpiderRemove(int ID)
        {
            return PartialView(spiderRepository.SpiderById(ID));
        }

        public string SpiderRemove(int ID)
        {
            string fullPathImage = Request.MapPath("/Document/img/Spider/" + spiderRepository.SpiderById(ID).Image);
            if (System.IO.File.Exists(fullPathImage))
            {
                System.IO.File.Delete(fullPathImage);
            }

            return spiderRepository.SpiderRemove(ID);
        }

        /// <پایان اسپایدر>
        /// ///////////////////////////////////Spider


        /// <شروع نمایندگی ها>
        /// ///////////////////////////////////Marketer

        public ActionResult P_MarketerReport(int PageId = 1, string PhoneNumber = "", int Status = 0, int InPageCount = 0)
        {
            if (PhoneNumber == "")
            {
                if (Status == 0)
                {
                    if (InPageCount == 0)
                    {
                        int count = marketerRepository.AllMarketerReports().Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.PhoneNumber = "";

                        ViewBag.Status = Status;

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        return PartialView(marketerRepository.AllMarketerReports().OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                    }
                    else
                    {

                        int count = marketerRepository.AllMarketerReports().Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.PhoneNumber = "";

                        ViewBag.Status = Status;

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        return PartialView(marketerRepository.AllMarketerReports().OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                    }
                }
                else
                {
                    if (Status == 1)
                    {
                        if (InPageCount == 0)
                        {
                            int count = marketerRepository.AllMarketerReports().Where(mr => mr.Status == false).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            ViewBag.PhoneNumber = "";

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(marketerRepository.AllMarketerReports().Where(mr => mr.Status == false).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                        }
                        else
                        {

                            int count = marketerRepository.AllMarketerReports().Where(mr => mr.Status == false).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            ViewBag.PhoneNumber = "";

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(marketerRepository.AllMarketerReports().Where(mr => mr.Status == false).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                        }
                    }
                    else if (Status == 2)
                    {
                        if (InPageCount == 0)
                        {
                            int count = marketerRepository.AllMarketerReports().Where(mr => mr.Status == true).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            ViewBag.PhoneNumber = "";

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(marketerRepository.AllMarketerReports().Where(mr => mr.Status == true).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                        }
                        else
                        {

                            int count = marketerRepository.AllMarketerReports().Where(mr => mr.Status == true).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            ViewBag.PhoneNumber = "";

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(marketerRepository.AllMarketerReports().Where(mr => mr.Status == true).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                        }
                    }
                }
            }
            else
            {
                if (Status == 0)
                {
                    if (InPageCount == 0)
                    {
                        int count = marketerRepository.AllMarketerReports().Where(mr => mr.User.PhoneNumber.Contains(PhoneNumber)).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.PhoneNumber = PhoneNumber;

                        ViewBag.Status = Status;

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        return PartialView(marketerRepository.AllMarketerReports().Where(mr => mr.User.PhoneNumber.Contains(PhoneNumber)).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                    }
                    else
                    {

                        int count = marketerRepository.AllMarketerReports().Where(mr => mr.User.PhoneNumber.Contains(PhoneNumber)).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.PhoneNumber = PhoneNumber;

                        ViewBag.Status = Status;

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        return PartialView(marketerRepository.AllMarketerReports().Where(mr => mr.User.PhoneNumber.Contains(PhoneNumber)).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                    }
                }
                else
                {
                    if (Status == 1)
                    {
                        if (InPageCount == 0)
                        {
                            int count = marketerRepository.AllMarketerReports().Where(mr => mr.Status == false && mr.User.PhoneNumber.Contains(PhoneNumber)).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            ViewBag.PhoneNumber = PhoneNumber;

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(marketerRepository.AllMarketerReports().Where(mr => mr.Status == false && mr.User.PhoneNumber.Contains(PhoneNumber)).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                        }
                        else
                        {

                            int count = marketerRepository.AllMarketerReports().Where(mr => mr.Status == false && mr.User.PhoneNumber.Contains(PhoneNumber)).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            ViewBag.PhoneNumber = PhoneNumber;

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(marketerRepository.AllMarketerReports().Where(mr => mr.Status == false && mr.User.PhoneNumber.Contains(PhoneNumber)).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                        }
                    }
                    else if (Status == 2)
                    {
                        if (InPageCount == 0)
                        {
                            int count = marketerRepository.AllMarketerReports().Where(mr => mr.Status == true && mr.User.PhoneNumber.Contains(PhoneNumber)).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            ViewBag.PhoneNumber = PhoneNumber;

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(marketerRepository.AllMarketerReports().Where(mr => mr.Status == true && mr.User.PhoneNumber.Contains(PhoneNumber)).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                        }
                        else
                        {

                            int count = marketerRepository.AllMarketerReports().Where(mr => mr.Status == true && mr.User.PhoneNumber.Contains(PhoneNumber)).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            ViewBag.PhoneNumber = PhoneNumber;

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(marketerRepository.AllMarketerReports().Where(mr => mr.Status == true && mr.User.PhoneNumber.Contains(PhoneNumber)).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                        }
                    }
                }
            }
            return PartialView();

        }

        public string ConfirmReport(int ID)
        {
            return marketerRepository.ChangeStatus(ID);
        }

        public ActionResult P_MarketerReportInfo(int ID)
        {
            return PartialView(marketerRepository.MarketerReportById(ID));
        }

        public string RemoveMarketerReport(int ID)
        {
            return marketerRepository.RemoveReport(ID);
        }

        /// <پایان نمایندگی ها>
        /// ///////////////////////////////////Marketer


        public ActionResult P_Revenues()
        {
            return PartialView();
        }

        public ActionResult P_OrderExplorer()
        {
            return PartialView();
        }

        public ActionResult P_TicketExplorer()
        {
            return PartialView();
        }

        public ActionResult P_Massage()
        {
            return PartialView();
        }
        public ActionResult P_MassageInfo()
        {
            return PartialView();
        }

        public ActionResult P_SupportPart()
        {
            return PartialView();
        }

        public ActionResult P_Partners()
        {
            return PartialView();
        }

        public ActionResult P_Customers()
        {
            return PartialView();
        }

    }
}