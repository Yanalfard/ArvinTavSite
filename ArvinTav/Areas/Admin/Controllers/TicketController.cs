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
    }
}