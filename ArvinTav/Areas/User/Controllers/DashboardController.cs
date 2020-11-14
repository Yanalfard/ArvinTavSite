using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
using ArvinTav.Classes;
=======
>>>>>>> 63f537089829e066438fbd9f57d2dcfc75036208
using DataLayer;

namespace ArvinTav.Areas.User.Controllers
{
    [Authorize(Roles = "Admin,PartAdmin,Marketer,Content,Customer")]
    public class DashboardController : Controller
    {
        private ArvinContext db = new ArvinContext();
        private IUserRepository userRepository;

        public DashboardController()
        {
            userRepository = new UserRepository(db);
        }

        // GET: User/Dashboard
        public ActionResult Index()
        {
            return View(userRepository.UserByPhoneNumber(User.Identity.Name));
        }

        [HttpGet]
        public ActionResult MyProfile()
        {
            DataLayer.User user = userRepository.UserByPhoneNumber(User.Identity.Name);
            FullRegsiterViewModel fullRegsiterViewModel = new FullRegsiterViewModel();
            fullRegsiterViewModel.FullName = user.FullName;
            fullRegsiterViewModel.Brand = user.Brand;
            fullRegsiterViewModel.Email = user.Email;
            fullRegsiterViewModel.Image = user.Image;
            return View(fullRegsiterViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyProfile(FullRegsiterViewModel fullRegsiterViewModel, HttpPostedFileBase ImageUp)
        {
            DataLayer.User UpdateUser = new DataLayer.User();

            if (ImageUp != null)
            {

                if (ImageUp.ContentType != "image/png" || ImageUp.ContentType != "image/jpeg" || ImageUp.ContentType != "image/jpg")
                {
                    ModelState.AddModelError("Image", "تصویر با فرمت png و jpeg معتبر است");
                    return View();
                }
                else
                {

                    var img = Bitmap.FromStream(ImageUp.InputStream);

                    if (img.Width > 600 || img.Height > 600)
                    {
                        ModelState.AddModelError("Image", "طول و عرض تصویر نباید بیشتر از 600 پیکسل باشد");
                        return View();
                    }
                    else
                    {
                        DataLayer.User user = userRepository.UserByPhoneNumber(User.Identity.Name);

                        if (user.Image != null)
                        {
                            System.IO.File.Delete(Server.MapPath("/Document/img/User/" + user.Image));
                        }

                        UpdateUser.Image = Guid.NewGuid() + Path.GetExtension(ImageUp.FileName);
                        ImageUp.SaveAs(Server.MapPath("/Document/img/User/" + UpdateUser.Image));

                        UpdateUser.PhoneNumber = User.Identity.Name;
                        UpdateUser.FullName = fullRegsiterViewModel.FullName;
                        UpdateUser.Email = fullRegsiterViewModel.Email;
                        UpdateUser.Brand = fullRegsiterViewModel.Brand;
                        userRepository.FullRegister(UpdateUser);

                        return RedirectToAction("Index");

                    }

                }

            }
            else
            {
                UpdateUser.PhoneNumber = User.Identity.Name;
                UpdateUser.FullName = fullRegsiterViewModel.FullName;
                UpdateUser.Email = fullRegsiterViewModel.Email;
                UpdateUser.Brand = fullRegsiterViewModel.Brand;
                userRepository.FullRegister(UpdateUser);

                return RedirectToAction("Index");
            }
        }

        public ActionResult P_UserBox()
        {
            return PartialView(userRepository.UserByPhoneNumber(User.Identity.Name));
        }


    }
}