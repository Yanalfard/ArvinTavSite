using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArvinTav.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Category/{ID?}")]
        public ActionResult Category(int? ID)
        {
            return View();
        }

        [Route("Products/{ID?}")]
        public ActionResult Products(int? ID)
        {
            return View();
        }

        [Route("Product/{ID?}")]
        public ActionResult Product(int? ID)
        {
            return View();
        }

        [Route("SubmitDomain/{ID?}")]
        public ActionResult SubmitDomain(int? ID)
        {
            return View();
        }
    }
}