﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArvinTav.Areas.Admin.Controllers
{
    public class FestivalController : Controller
    {
        // GET: Admin/Festival
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
        public ActionResult P_Edit()
        {
            return PartialView();
        }
        public ActionResult P_Remove()
        {
            return PartialView();
        }
    }
}