using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArvinTav.Areas.Admin.Controllers
{
    public class TicketController : Controller
    {
        // GET: Admin/Ticket
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult P_InnerTicket(int? ID)
        {
            return PartialView();
        }

        //InnerTicket
        public ActionResult InnerTicket(int? ID)
        {
            return View();
        }

        public ActionResult P_Info(int? ID)
        {
            return PartialView();
        }
    }
}