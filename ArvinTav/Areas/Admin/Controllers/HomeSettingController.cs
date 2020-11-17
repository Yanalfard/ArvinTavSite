using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeSettingController : Controller
    {
        private ArvinContext db = new ArvinContext();
        private ISliderRepository sliderRepository;

        public HomeSettingController()
        {
            
            sliderRepository = new SliderRepository(db);
        }

        // GET: Admin/HomeSetting
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult P_Slider()
        {
            return PartialView(sliderRepository.AllSliders());
        }

        public ActionResult P_SliderCreate()
        {
            return PartialView();
        }

        [HttpPost]
        public string SliderCreate(string Title, string Link, string Image)
        {
            return sliderRepository.SliderCreate(Title, Link, Image);
        }

        public ActionResult P_SliderEdit(int ID)
        {
            return PartialView();
        }

        public string SliderEdit(int ID, string Title, string Link, string Image)
        {
            if (Image == "")
            {
                return sliderRepository.SliderEdit(ID, Title, Link, null);
            }
            else
            {
                return sliderRepository.SliderEdit(ID, Title, Link, Image);
            }


        }

        public ActionResult P_SliderRemove(int ID)
        {
            return PartialView();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                sliderRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}