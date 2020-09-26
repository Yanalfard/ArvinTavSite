using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArvinTav.Areas.Admin.Controllers
{
    public class HostingController : Controller
    {
        // GET: Admin/Hosting
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult P_List()
        {
            return PartialView();
        }

        public ActionResult P_Create()
        {
            return PartialView();
        }

        public string Create()
        {
            return "true";
        }

        public ActionResult P_Edit()
        {
            return PartialView();
        }

        public string Edit()
        {
            return "true";
        }

        public ActionResult P_Remove()
        {
            return PartialView();
        }

        public string Remove()
        {
            return "true";
        }
    }
}