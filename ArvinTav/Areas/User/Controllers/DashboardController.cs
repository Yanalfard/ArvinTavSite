using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArvinTav.Classes;

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
            DataLayer.User user = userRepository.UserByPhoneNumber(User.Identity.Name);

            if(string.IsNullOrEmpty(fullRegsiterViewModel.FullName) || string.IsNullOrEmpty(fullRegsiterViewModel.Brand) || string.IsNullOrEmpty(fullRegsiterViewModel.Email))
            {
                FullRegsiterViewModel fullReplyRegsiterViewModel = new FullRegsiterViewModel();
                fullReplyRegsiterViewModel.FullName = user.FullName;
                fullReplyRegsiterViewModel.Brand = user.Brand;
                fullReplyRegsiterViewModel.Email = user.Email;
                fullReplyRegsiterViewModel.Image = user.Image;
                ViewBag.Erorr = "تمامی گزینه ها را پر کنید";
                return View(fullRegsiterViewModel);
            }
            else
            {
                if (fullRegsiterViewModel.Brand.Contains("'"))
                {
                    ModelState.AddModelError("Brand", "نام تجاری نا معتبر است");
                    FullRegsiterViewModel fullReplyRegsiterViewModel = new FullRegsiterViewModel();
                    fullReplyRegsiterViewModel.FullName = user.FullName;
                    fullReplyRegsiterViewModel.Brand = user.Brand;
                    fullReplyRegsiterViewModel.Email = user.Email;
                    fullReplyRegsiterViewModel.Image = user.Image;
                    return View(fullRegsiterViewModel);
                }
                else
                {
                    if (fullRegsiterViewModel.Email.Contains("'"))
                    {
                        ModelState.AddModelError("Email", "ایمیل نا معتبر است");
                        FullRegsiterViewModel fullReplyRegsiterViewModel = new FullRegsiterViewModel();
                        fullReplyRegsiterViewModel.FullName = user.FullName;
                        fullReplyRegsiterViewModel.Brand = user.Brand;
                        fullReplyRegsiterViewModel.Email = user.Email;
                        fullReplyRegsiterViewModel.Image = user.Image;
                        return View(fullRegsiterViewModel);
                    }
                    else
                    {
                        if (fullRegsiterViewModel.FullName.Contains("'"))
                        {
                            ModelState.AddModelError("نام نا معتبر است", "تصویر با فرمت png و jpeg معتبر است");
                            FullRegsiterViewModel fullReplyRegsiterViewModel = new FullRegsiterViewModel();
                            fullReplyRegsiterViewModel.FullName = user.FullName;
                            fullReplyRegsiterViewModel.Brand = user.Brand;
                            fullReplyRegsiterViewModel.Email = user.Email;
                            fullReplyRegsiterViewModel.Image = user.Image;
                            return View(fullRegsiterViewModel);
                        }
                        else
                        {
                            if (ImageUp != null)
                            {

                                if (ImageUp.ContentType != "image/png" && ImageUp.ContentType != "image/jpeg" && ImageUp.ContentType != "image/jpg")
                                {
                                    ModelState.AddModelError("Image", "تصویر با فرمت png و jpeg معتبر است");
                                    FullRegsiterViewModel fullReplyRegsiterViewModel = new FullRegsiterViewModel();
                                    fullReplyRegsiterViewModel.FullName = user.FullName;
                                    fullReplyRegsiterViewModel.Brand = user.Brand;
                                    fullReplyRegsiterViewModel.Email = user.Email;
                                    fullReplyRegsiterViewModel.Image = user.Image;
                                    return View(fullRegsiterViewModel);
                                }
                                else
                                {

                                    var img = Bitmap.FromStream(ImageUp.InputStream);

                                    if (img.Width > 5000 || img.Height > 5000)
                                    {
                                        ModelState.AddModelError("Image", "طول و عرض تصویر نباید بیشتر از 4000 پیکسل باشد");
                                        FullRegsiterViewModel fullReplyRegsiterViewModel = new FullRegsiterViewModel();
                                        fullReplyRegsiterViewModel.FullName = user.FullName;
                                        fullReplyRegsiterViewModel.Brand = user.Brand;
                                        fullReplyRegsiterViewModel.Email = user.Email;
                                        fullReplyRegsiterViewModel.Image = user.Image;
                                        return View(fullRegsiterViewModel);
                                    }
                                    else
                                    {
                                        
                                        if(ImageUp.ContentLength> 3000000)
                                        {
                                            ModelState.AddModelError("Image", "حجم تصویر نباید بیشتر از 3 مگابایت باشد");
                                            FullRegsiterViewModel fullReplyRegsiterViewModel = new FullRegsiterViewModel();
                                            fullReplyRegsiterViewModel.FullName = user.FullName;
                                            fullReplyRegsiterViewModel.Brand = user.Brand;
                                            fullReplyRegsiterViewModel.Email = user.Email;
                                            fullReplyRegsiterViewModel.Image = user.Image;
                                            return View(fullRegsiterViewModel);
                                        }

                                        if (string.IsNullOrEmpty(user.Image)==false)
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
                    }
                }
            }

        }

        public ActionResult P_UserBox()
        {
            return PartialView(userRepository.UserByPhoneNumber(User.Identity.Name));
        }


    }
}