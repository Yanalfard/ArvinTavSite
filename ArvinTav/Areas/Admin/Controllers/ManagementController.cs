using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArvinTav.Areas.Admin.Controllers
{
    public class ManagementController : Controller
    {
        // GET: Admin/Management
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult P_Spider()
        {
            return PartialView();
        }

        public ActionResult P_MarketerReport()
        {
            return PartialView();
        }

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
    }
}