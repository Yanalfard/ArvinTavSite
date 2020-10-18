using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArvinTav.Areas.Admin.Controllers
{
    public class MarketerController : Controller
    {
        // GET: Admin/Marketer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CraateReport()
        {
            return PartialView();
        }

        [HttpPost]
        public string CraateReport(string Title)
        {
            return "";
        }
    }
}