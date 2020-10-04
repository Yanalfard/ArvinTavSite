using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        ArvinContext db = new ArvinContext();
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}