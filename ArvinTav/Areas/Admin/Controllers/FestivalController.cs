using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    public class FestivalController : Controller
    {
        IFestivalRepository festivalRepository;
        ArvinContext db = new ArvinContext();

        public FestivalController()
        {
            festivalRepository = new FestivalRepository(db);
        }


        // GET: Admin/Festival
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult P_List()
        {
            return PartialView(festivalRepository.AllDiscounts());
        }
        public ActionResult P_Create()
        {
            return PartialView();
        }

        [HttpPost]
        public string Create(string Code, int Percentage)
        {
            return festivalRepository.Create(Code, Percentage);
        }

        public ActionResult P_Edit(int ID)
        {
            return PartialView(festivalRepository.DiscountById(ID));
        }

        [HttpPost]
        public string Edit(int ID, string Code, int Percentage)
        {
            return festivalRepository.Edit(ID, Code, Percentage);
        }

        public ActionResult P_Remove(int ID)
        {
            return PartialView(festivalRepository.DiscountById(ID));
        }

        public string Remove(int ID)
        {
            return festivalRepository.Remove(ID);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                festivalRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}