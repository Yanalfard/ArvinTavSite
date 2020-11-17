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
        private ArvinContext db = new ArvinContext();
        private ISpiderRepository spiderRepository;
        private IMarketerRepository marketerRepository;
        private IStatisticRepository statisticRepository;
        private IMassageRepository massageRepository;
        private ITicketRepository ticketRepository;
        private IPartnerRepository partnerRepository;
        private ICustomerRepository customerRepository;
        private IServiceCategoryRepository serviceCategoryRepository;

        public ManagementController()
        {
            spiderRepository = new SpiderRepository(db);
            marketerRepository = new MarketerRepository(db);
            statisticRepository = new StatisticRepository(db);
            massageRepository = new MassageRepository(db);
            ticketRepository = new TicketRepository(db);
            partnerRepository = new PartnerRepository(db);
            customerRepository = new CustomerRepository(db);
            serviceCategoryRepository = new ServiceCategoryRepository(db);
        }

        // GET: Admin/Management
        public ActionResult Index()
        {
            return View();
        }


        /// <شروع اسپایدر>
        /// ///////////////////////////////////Spider

        [Authorize(Roles = "Admin,Content")]
        public ActionResult P_SpiderCategory()
        {
            return PartialView();
        }

        [Authorize(Roles = "Admin,Content")]
        public ActionResult P_SpiderCategoryCreate()
        {
            return PartialView();
        }

        [Authorize(Roles = "Admin,Content")]
        public ActionResult P_SpiderCategoryEdit(int ID)
        {
            return PartialView(spiderRepository.spiderCategoryById(ID));
        }

        [Authorize(Roles = "Admin,Content")]
        public string SpiderCategoryCreate(string Title)
        {
            return spiderRepository.AddSpiderCategory(Title);
        }

        [Authorize(Roles = "Admin,Content")]
        public string SpiderCategoryEdit(int ID, string Title)
        {
            return spiderRepository.EditSpiderCategory(ID, Title);
        }

        [Authorize(Roles = "Admin,Content")]
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

        [Authorize(Roles = "Admin,Content")]
        public ActionResult P_SpiderCreate()
        {
            return PartialView(spiderRepository.AllspiderCategories());
        }

        [Authorize(Roles = "Admin,Content")]
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SpiderCreate(int Category, string Title, string Description, string Image, List<string> SeoTages)
        {
            return Json(spiderRepository.AddSpider(Category, Title, Description, Image, SeoTages));
        }

        [Authorize(Roles = "Admin,Content")]
        public ActionResult P_SpiderEdit(int ID)
        {
            SpiderEditViewModel spiderEditViewModel = new SpiderEditViewModel();
            spiderEditViewModel.Spider = spiderRepository.SpiderById(ID);
            spiderEditViewModel.spiderCategories = spiderRepository.AllspiderCategories();
            return PartialView(spiderEditViewModel);
        }

        [Authorize(Roles = "Admin,Content")]
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SpiderEdit(int ID, int Category, string Title, string Description, string Image, List<string> SeoTages)
        {
            if (Image != null || Image != "")
            {
                string fullPathImage = Request.MapPath("/Document/img/Spider/" + spiderRepository.SpiderById(ID).Image);
                if (System.IO.File.Exists(fullPathImage))
                {
                    System.IO.File.Delete(fullPathImage);
                }
            }
            return Json(spiderRepository.SpiderEdit(ID, Category, Title, Description, Image, SeoTages));
        }

        [Authorize(Roles = "Admin,Content")]
        public ActionResult P_SpiderRemove(int ID)
        {
            return PartialView(spiderRepository.SpiderById(ID));
        }

        [Authorize(Roles = "Admin,Content")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public string ConfirmReport(int ID)
        {
            return marketerRepository.ChangeStatus(ID);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult P_MarketerReportInfo(int ID)
        {
            return PartialView(marketerRepository.MarketerReportById(ID));
        }

        [Authorize(Roles = "Admin")]
        public string RemoveMarketerReport(int ID)
        {
            return marketerRepository.RemoveReport(ID);
        }

        /// <پایان نمایندگی ها>
        /// ///////////////////////////////////Marketer

        [Authorize(Roles = "Admin")]
        public ActionResult P_Revenues()
        {
            return PartialView(statisticRepository.AllRevenues());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult P_OrderExplorer()
        {
            return PartialView(statisticRepository.AllOrderExplorer());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult P_TicketExplorer()
        {
            return PartialView(statisticRepository.TicketExplorer());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult P_Massage(int PageId = 1, string result = "", int Status = 0, int InPageCount = 0)
        {

            if (result == "")
            {
                if (Status == 0)
                {
                    if (InPageCount == 0)
                    {
                        int count = massageRepository.AllMasssages().Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.result = "";

                        ViewBag.Status = Status;

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        return PartialView(massageRepository.AllMasssages().OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                    }
                    else
                    {

                        int count = massageRepository.AllMasssages().Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.result = "";

                        ViewBag.Status = Status;

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        return PartialView(massageRepository.AllMasssages().OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                    }
                }
                else
                {
                    if (Status == 1)
                    {

                        if (InPageCount == 0)
                        {
                            int count = massageRepository.AllMasssages().Where(m => m.Seen == true).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            ViewBag.result = "";

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(massageRepository.AllMasssages().Where(m => m.Seen == true).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                        }
                        else
                        {

                            int count = massageRepository.AllMasssages().Where(m => m.Seen == true).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            ViewBag.result = "";

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(massageRepository.AllMasssages().Where(m => m.Seen == true).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                        }
                    }
                    if (Status == 2)
                    {

                        if (InPageCount == 0)
                        {
                            int count = massageRepository.AllMasssages().Where(m => m.Seen == false).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            ViewBag.result = "";

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(massageRepository.AllMasssages().Where(m => m.Seen == false).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                        }
                        else
                        {

                            int count = massageRepository.AllMasssages().Where(m => m.Seen == false).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            ViewBag.result = "";

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(massageRepository.AllMasssages().Where(m => m.Seen == false).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
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
                        int count = massageRepository.AllMasssages().Where(m => m.FullName.Contains(result)).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.result = result;

                        ViewBag.Status = Status;

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        return PartialView(massageRepository.AllMasssages().Where(m => m.FullName.Contains(result)).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                    }
                    else
                    {

                        int count = massageRepository.AllMasssages().Where(m => m.FullName.Contains(result)).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.result = result;

                        ViewBag.Status = Status;

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        return PartialView(massageRepository.AllMasssages().Where(m => m.FullName.Contains(result)).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                    }
                }
                else
                {
                    if (Status == 1)
                    {

                        if (InPageCount == 0)
                        {
                            int count = massageRepository.AllMasssages().Where(m => m.FullName.Contains(result) && m.Seen == true).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            ViewBag.result = result;

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(massageRepository.AllMasssages().Where(m => m.FullName.Contains(result) && m.Seen == true).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                        }
                        else
                        {

                            int count = massageRepository.AllMasssages().Where(m => m.FullName.Contains(result) && m.Seen == true).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            ViewBag.result = result;

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(massageRepository.AllMasssages().Where(m => m.FullName.Contains(result) && m.Seen == true).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                        }


                    }
                    if (Status == 2)
                    {

                        if (InPageCount == 0)
                        {
                            int count = massageRepository.AllMasssages().Where(m => m.FullName.Contains(result) && m.Seen == true).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            ViewBag.result = result;

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(massageRepository.AllMasssages().Where(m => m.FullName.Contains(result) && m.Seen == true).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                        }
                        else
                        {

                            int count = massageRepository.AllMasssages().Where(m => m.FullName.Contains(result) && m.Seen == false).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            ViewBag.result = result;

                            ViewBag.Status = Status;

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            return PartialView(massageRepository.AllMasssages().Where(m => m.FullName.Contains(result) && m.Seen == false).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                        }

                    }

                }

            }
            return PartialView();

        }

        [Authorize(Roles = "Admin")]
        public ActionResult P_MassageInfo(int ID)
        {
            return PartialView(massageRepository.massageById(ID));
        }

        [Authorize(Roles = "Admin")]
        public string ConfirmMassage(int ID)
        {
            bool Confirm = massageRepository.ConfirmMassage(ID);
            if (Confirm == true)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        [Authorize(Roles = "Admin")]
        public string RemoveMassage(int ID)
        {
            bool Remove = massageRepository.RemoveMassage(ID);

            if (Remove == true)
            {
                return "true";
            }
            else
            {
                return "false";
            }

        }

        /// <شروع بخش پشتیبانی>
        /// ///////////////////////////////////Support Part

        [Authorize(Roles = "Admin")]
        public ActionResult P_SupportPart(string Result = "")
        {
            if (Result == "")
            {
                ViewBag.Result = "";
                return PartialView(ticketRepository.ticketCategories());
            }
            else
            {
                ViewBag.Result = Result;
                return PartialView(ticketRepository.ticketCategories().Where(tc => tc.Title.Contains(Result)));
            }

        }

        [Authorize(Roles = "Admin")]
        public ActionResult P_SupportCreated()
        {
            return PartialView();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public string SupportCreate(string Title, int IsActive)
        {
            return ticketRepository.SupportCreate(Title, IsActive);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult P_SupportEdit(int ID)
        {
            return PartialView(ticketRepository.ticketCategoryById(ID));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public string SupportEdit(int ID, string Title, int IsActive)
        {
            return ticketRepository.SupportEdit(ID, Title, IsActive);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult P_SupportRemove(int ID)
        {
            return PartialView(ticketRepository.ticketCategoryById(ID));
        }

        [Authorize(Roles = "Admin")]
        public string RemoveSupoort(int ID)
        {
            return ticketRepository.RemoveSupoort(ID);
        }


        /// <پایان بخش پشتیبانی>
        /// ///////////////////////////////////Support Part



        /// <شروع همکاران>
        /// ///////////////////////////////////Partners

        [Authorize(Roles = "Admin")]
        public ActionResult P_Partners(int PageId = 1, string result = "", int InPageCount = 0)
        {
            if (result == "")
            {
                if (InPageCount == 0)
                {
                    int count = partnerRepository.Allpartners().Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.result = "";

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(partnerRepository.Allpartners().OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = partnerRepository.Allpartners().Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.result = "";


                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(partnerRepository.Allpartners().OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                }
            }
            else
            {
                if (InPageCount == 0)
                {
                    int count = partnerRepository.Allpartners().Where(p => p.Title.Contains(result)).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.result = result;

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(partnerRepository.Allpartners().Where(p => p.Title.Contains(result)).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = partnerRepository.Allpartners().Where(p => p.Title.Contains(result)).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.result = result;


                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(partnerRepository.Allpartners().Where(p => p.Title.Contains(result)).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                }
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult P_PartnersCreated()
        {
            return PartialView();
        }

        [Authorize(Roles = "Admin")]
        public string CreatePartner(string Title, string PhoneNumber, string Logo)
        {
            return partnerRepository.CreatePartner(Title, PhoneNumber, Logo);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult P_PartnersEdit(int ID)
        {
            return PartialView(partnerRepository.partnerById(ID));
        }

        [Authorize(Roles = "Admin")]
        public string EditPartner(int ID, string Title, string PhoneNumber, string Logo)
        {
            if (Logo != "")
            {
                string fullPathImage = Request.MapPath("/Document/img/Partner/" + partnerRepository.partnerById(ID).Logo);

                if (System.IO.File.Exists(fullPathImage))
                {
                    System.IO.File.Delete(fullPathImage);
                }
            }
            return partnerRepository.EditPartner(ID, Title, PhoneNumber, Logo);
        }
        public ActionResult P_PartnersRemove(int ID)
        {
            return PartialView(partnerRepository.partnerById(ID));
        }

        [Authorize(Roles = "Admin")]
        public string RemovePartner(int ID)
        {
            string fullPathImage = Request.MapPath("/Document/img/Partner/" + partnerRepository.partnerById(ID).Logo);

            if (System.IO.File.Exists(fullPathImage))
            {
                System.IO.File.Delete(fullPathImage);
            }

            return partnerRepository.RemovePartner(ID);

        }

        /// <پایان همکاران>
        /// ///////////////////////////////////Partners


        /// <شروع مشتریان>
        /// ///////////////////////////////////Customers

        [Authorize(Roles = "Admin")]
        public ActionResult P_Customers(int PageId = 1, string result = "", int InPageCount = 0)
        {
            if (result == "")
            {
                if (InPageCount == 0)
                {
                    int count = customerRepository.AllCustomers().Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.result = "";

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(customerRepository.AllCustomers().OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = customerRepository.AllCustomers().Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.result = "";


                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(customerRepository.AllCustomers().OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                }
            }
            else
            {
                if (InPageCount == 0)
                {
                    int count = customerRepository.AllCustomers().Where(p => p.Title.Contains(result)).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.result = result;

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(customerRepository.AllCustomers().Where(p => p.Title.Contains(result)).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = customerRepository.AllCustomers().Where(p => p.Title.Contains(result)).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.result = result;


                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(customerRepository.AllCustomers().Where(p => p.Title.Contains(result)).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                }
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult P_CustomersCreated()
        {
            return PartialView();
        }

        [Authorize(Roles = "Admin")]
        public string CreateCustomer(string Title, string PhoneNumber, string Logo)
        {
            return customerRepository.CreateCustomer(Title, PhoneNumber, Logo);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult P_CustomersEdit(int ID)
        {
            return PartialView(customerRepository.CustomerById(ID));
        }

        [Authorize(Roles = "Admin")]
        public string EditCustomer(int ID, string Title, string PhoneNumber, string Logo)
        {
            if (Logo != "")
            {
                string fullPathImage = Request.MapPath("/Document/img/Customer/" + customerRepository.CustomerById(ID).Logo);

                if (System.IO.File.Exists(fullPathImage))
                {
                    System.IO.File.Delete(fullPathImage);
                }
            }
            return customerRepository.EditCustomer(ID, Title, PhoneNumber, Logo);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult P_CustomersRemove(int ID)
        {
            return PartialView(customerRepository.CustomerById(ID));
        }

        [Authorize(Roles = "Admin")]
        public string RemoveCustomer(int ID)
        {
            string fullPathImage = Request.MapPath("/Document/img/Customer/" + customerRepository.CustomerById(ID).Logo);

            if (System.IO.File.Exists(fullPathImage))
            {
                System.IO.File.Delete(fullPathImage);
            }

            return customerRepository.RemoveCustomer(ID);

        }

        /// <پایان مشتریان>
        /// ///////////////////////////////////Customers
        /// 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                spiderRepository.Dispose();
                marketerRepository.Dispose();
                statisticRepository.Dispose();
                massageRepository.Dispose();
                ticketRepository.Dispose();
                partnerRepository.Dispose();
                customerRepository.Dispose();
                serviceCategoryRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}