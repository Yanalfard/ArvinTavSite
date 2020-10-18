using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArvinTav.Areas.Admin.Controllers
{
    public class HomeSettingController : Controller
    {
        // GET: Admin/HomeSetting
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult P_Slider()
        {
            return PartialView();
        }
    }
}