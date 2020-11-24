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
            return PartialView(sliderRepository.SliderById(ID));
        }

        public string SliderEdit(int ID, string Title, string Link, string Image)
        {
            if (Image == "" || Image == null)
            {
                return sliderRepository.SliderEdit(ID, Title, Link, null);
            }
            else
            {
                string fullPathImage = Request.MapPath("/Document/img/Slider/" + sliderRepository.SliderById(ID).Image);
                if (System.IO.File.Exists(fullPathImage))
                {
                    System.IO.File.Delete(fullPathImage);
                }
                return sliderRepository.SliderEdit(ID, Title, Link, Image);
            }


        }
        

        public string SliderRemove(int ID)
        {
            string fullPathImage = Request.MapPath("/Document/img/Slider/" + sliderRepository.SliderById(ID).Image);
            if (System.IO.File.Exists(fullPathImage))
            {
                System.IO.File.Delete(fullPathImage);
            }


            return sliderRepository.SliderRemove(ID);
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