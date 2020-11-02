using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private ArvinContext db = new ArvinContext();
        private IUserRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository(db);
        }

        // GET: Admin/User
        public ActionResult Index(int PageId = 1, string PhoneNumber = "", int Degree = 0, int InPageCount = 0)
        {
            if (PhoneNumber == "")
            {
                if (Degree == 0)
                {
                    if (InPageCount == 0)
                    {
                        int count = userRepository.AllUser().Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.Degree = Degree;

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        return View(userRepository.AllRoles());
                    }
                    else
                    {

                        int count = userRepository.AllUser().Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.Degree = Degree;

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        return View(userRepository.AllRoles());

                    }
                }
                else
                {

                    if (InPageCount == 0)
                    {
                        int count = userRepository.AllUser().Where(u => u.UserRole.RoleID == Degree).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.Degree = Degree;

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        return View(userRepository.AllRoles());
                    }
                    else
                    {

                        int count = userRepository.AllUser().Where(u => u.UserRole.RoleID == Degree).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.Degree = Degree;

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        return View(userRepository.AllRoles());

                    }

                }
            }
            else
            {
                if (Degree == 0)
                {
                    if (InPageCount == 0)
                    {
                        int count = userRepository.AllUser().Where(u => u.PhoneNumber.Contains(PhoneNumber)).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = PhoneNumber;

                        ViewBag.Degree = Degree;

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        return View(userRepository.AllRoles());
                    }
                    else
                    {

                        int count = userRepository.AllUser().Where(u => u.PhoneNumber.Contains(PhoneNumber)).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = PhoneNumber;

                        ViewBag.Degree = Degree;

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        return View(userRepository.AllRoles());

                    }
                }
                else
                {
                    if (InPageCount == 0)
                    {
                        int count = userRepository.AllUser().Where(u => u.UserRole.RoleID == Degree && u.PhoneNumber.Contains(PhoneNumber)).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = PhoneNumber;

                        ViewBag.Degree = Degree;

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        return View(userRepository.AllRoles());
                    }
                    else
                    {

                        int count = userRepository.AllUser().Where(u => u.UserRole.RoleID == Degree && u.PhoneNumber.Contains(PhoneNumber)).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = PhoneNumber;

                        ViewBag.Degree = Degree;

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        return View(userRepository.AllRoles());

                    }
                }
            }

        }
        public ActionResult P_List(int PageId = 1, string PhoneNumber = "", int Degree = 0, int InPageCount = 0)
        {
            if (PhoneNumber == "")
            {
                if (Degree == 0)
                {
                    if (InPageCount == 0)
                    {
                        int count = userRepository.AllUser().Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.Degree = Degree;

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        return View(userRepository.AllUser().OrderByDescending(u => u.FinalLoginTime).Skip(skip).Take(18).ToList());
                    }
                    else
                    {

                        int count = userRepository.AllUser().Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.Degree = Degree;

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        return View(userRepository.AllUser().OrderByDescending(u => u.FinalLoginTime).Skip(skip).Take(InPageCount).ToList());

                    }
                }
                else
                {
                    if (InPageCount == 0)
                    {
                        int count = userRepository.AllUser().Where(u => u.UserRole.RoleID == Degree).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.Degree = Degree;

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        return View(userRepository.AllUser().Where(u => u.UserRole.RoleID == Degree).OrderByDescending(u => u.FinalLoginTime).Skip(skip).Take(18).ToList());
                    }
                    else
                    {

                        int count = userRepository.AllUser().Where(u => u.UserRole.RoleID == Degree).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.Degree = Degree;

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        return View(userRepository.AllUser().Where(u => u.UserRole.RoleID == Degree).OrderByDescending(u => u.FinalLoginTime).Skip(skip).Take(InPageCount).ToList());

                    }
                }
            }
            else
            {
                if (Degree == 0)
                {
                    if (InPageCount == 0)
                    {
                        int count = userRepository.AllUser().Where(u => u.PhoneNumber.Contains(PhoneNumber)).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = PhoneNumber;

                        ViewBag.Degree = Degree;

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        return View(userRepository.AllUser().Where(u => u.PhoneNumber.Contains(PhoneNumber)).OrderByDescending(u => u.FinalLoginTime).Skip(skip).Take(18).ToList());
                    }
                    else
                    {

                        int count = userRepository.AllUser().Where(u => u.PhoneNumber.Contains(PhoneNumber)).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = PhoneNumber;

                        ViewBag.Degree = Degree;

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        return View(userRepository.AllUser().Where(u => u.PhoneNumber.Contains(PhoneNumber)).OrderByDescending(u => u.FinalLoginTime).Skip(skip).Take(InPageCount).ToList());

                    }
                }
                else
                {
                    if (Degree == 1)
                    {
                        if (InPageCount == 0)
                        {
                            int count = userRepository.AllUser().Where(u => u.UserRole.RoleID == Degree && u.PhoneNumber.Contains(PhoneNumber)).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            ViewBag.Result = PhoneNumber;

                            ViewBag.Degree = Degree;

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            return View(userRepository.AllUser().Where(u => u.UserRole.RoleID == Degree && u.PhoneNumber.Contains(PhoneNumber)).OrderByDescending(u => u.FinalLoginTime).Skip(skip).Take(18).ToList());
                        }
                        else
                        {

                            int count = userRepository.AllUser().Where(u => u.UserRole.RoleID == Degree && u.PhoneNumber.Contains(PhoneNumber)).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            ViewBag.Result = PhoneNumber;

                            ViewBag.Degree = Degree;

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            return View(userRepository.AllUser().Where(u => u.UserRole.RoleID == Degree && u.PhoneNumber.Contains(PhoneNumber)).OrderByDescending(u => u.FinalLoginTime).Skip(skip).Take(InPageCount).ToList());

                        }
                    }
                    else if (Degree == 2)
                    {
                        if (InPageCount == 0)
                        {
                            int count = userRepository.AllUser().Where(u => u.UserRole.RoleID < Degree && u.PhoneNumber.Contains(PhoneNumber)).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            ViewBag.Result = PhoneNumber;

                            ViewBag.Degree = Degree;

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            return View(userRepository.AllUser().Where(u => u.UserRole.RoleID < Degree && u.PhoneNumber.Contains(PhoneNumber)).OrderByDescending(u => u.FinalLoginTime).Skip(skip).Take(18).ToList());
                        }
                        else
                        {

                            int count = userRepository.AllUser().Where(u => u.UserRole.RoleID < Degree && u.PhoneNumber.Contains(PhoneNumber)).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            ViewBag.Result = PhoneNumber;

                            ViewBag.Degree = Degree;

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            return View(userRepository.AllUser().Where(u => u.UserRole.RoleID < Degree && u.PhoneNumber.Contains(PhoneNumber)).OrderByDescending(u => u.FinalLoginTime).Skip(skip).Take(InPageCount).ToList());

                        }
                    }
                }
            }


            return View();
        }
        public ActionResult P_Edit(int ID)
        {
            UserEditInAdminViewModel userEditInAdminViewModel = new UserEditInAdminViewModel();
            userEditInAdminViewModel.user = userRepository.UserById(ID);
            userEditInAdminViewModel.userRoles = userRepository.AllRoles();
            return View(userEditInAdminViewModel);
        }

        public string Edit(int ID, string FullName, string Brand, string Email, int UserRole)
        {
            if (UserRole == 0)
            {
                return "Erorr : یکی از نقش هارا وارد کنید";
            }
            return userRepository.EditInAdmin(ID, FullName, Brand, Email, UserRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}