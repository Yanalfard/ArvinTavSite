using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,PartAdmin,Marketer,Content")]
    public class MarketerController : Controller
    {
        ArvinContext db = new ArvinContext();
        IMarketerRepository marketerRepository;
        IUserRepository userRepository;

        public MarketerController()
        {
            marketerRepository = new MarketerRepository(db);
            userRepository = new UserRepository(db);
        }

        // GET: Admin/Marketer
        public ActionResult Index(int PageId = 1, int InPageCount = 0)
        {
            if (InPageCount == 0)
            {
                int count = marketerRepository.AllMarketerReportByMarketer(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Count();

                var skip = (PageId - 1) * 18;

                ViewBag.pageid = PageId;

                ViewBag.PageCount = count / 18;

                ViewBag.InPageCount = InPageCount;


                return View(marketerRepository.AllMarketerReportByMarketer(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList());
            }
            else
            {

                int count = marketerRepository.AllMarketerReportByMarketer(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Count();

                var skip = (PageId - 1) * InPageCount;

                ViewBag.pageid = PageId;

                ViewBag.PageCount = count / InPageCount;

                ViewBag.InPageCount = InPageCount;

                return View(marketerRepository.AllMarketerReportByMarketer(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList());
            }
        }

        public ActionResult CraateReport()
        {
            return PartialView();
        }

        [HttpPost]
        public string CraateReport(string Title, string Description)
        {
            return "";
        }

    }
}