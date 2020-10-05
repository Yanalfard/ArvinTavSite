using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArvinTav.Areas.Admin.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Admin/Project
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult P_Create()
        {
            return PartialView();
        }

        [HttpPost]
        public  string Create()
        {
            return "true";
        }

        public ActionResult P_Edit(int ID)
        {
            return PartialView();
        }

        [HttpPost]
        public string Edit()
        {
            return "true";
        }

        public ActionResult P_Remove(int ID)
        {
            return PartialView();
        }

        public string Remove(int ID)
        {
            return "";
        }


    }
}