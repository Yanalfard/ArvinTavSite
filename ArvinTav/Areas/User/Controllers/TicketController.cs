using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.User.Controllers
{
    [Authorize(Roles = "Admin,PartAdmin,Marketer,Content,Customer")]
    public class TicketController : Controller
    {


        private ArvinContext db = new ArvinContext();
        private ITicketRepository ticketRepository;
        private IUserRepository userRepository;
        public TicketController()
        {
            ticketRepository = new TicketRepository(db);
            userRepository = new UserRepository(db);
        }

        // GET: User/Ticket
        public ActionResult Index(int PageId = 1, int InPageCount = 0)
        {
            if (InPageCount == 0)
            {
                int count = ticketRepository.AllTicketForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Count();

                var skip = (PageId - 1) * 18;

                ViewBag.PageId = PageId;

                ViewBag.PageCount = count / 18;

                ViewBag.InPageCount = InPageCount;

                return View();
            }
            else
            {

                int count = ticketRepository.AllTicketForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Count();

                var skip = (PageId - 1) * InPageCount;

                ViewBag.PageId = PageId;

                ViewBag.PageCount = count / InPageCount;

                ViewBag.InPageCount = InPageCount;

                return View();
            }
        }

        public ActionResult P_List(int PageId = 1, int InPageCount = 0)
        {
            if (InPageCount == 0)
            {
                int count = ticketRepository.AllTicketForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Count();

                var skip = (PageId - 1) * 18;

                ViewBag.PageId = PageId;

                ViewBag.PageCount = count / 18;

                ViewBag.InPageCount = InPageCount;

                return PartialView(ticketRepository.AllTicketForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
            }
            else
            {

                int count = ticketRepository.AllTicketForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).Count();

                var skip = (PageId - 1) * InPageCount;

                ViewBag.PageId = PageId;

                ViewBag.PageCount = count / InPageCount;

                ViewBag.InPageCount = InPageCount;

                return PartialView(ticketRepository.AllTicketForUser(userRepository.UserByPhoneNumber(User.Identity.Name).UserID).OrderBy(v => v.ID).ToList());
            }
        }

        public ActionResult InnerTicket(int ID)
        {
            return PartialView(ticketRepository.GetInnerTicket(ID));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendMassage(int TicketID, string Text, HttpPostedFileBase File)
        {
            if (File != null)
            {
                if (File.ContentType != "application/pdf" && File.ContentType != "image/jpg" && File.ContentType != "image/png" && File.ContentType != "image/jpeg")
                {

                    return Redirect("InnerTicket?ID=" + TicketID + "&Erorr=1");
                }
                else
                {
                    if(File.ContentLength> 3000000)
                    {
                        return Redirect("InnerTicket?ID=" + TicketID + "&Erorr=2");
                    }

                    string MassageFile = null;
                    MassageFile = Guid.NewGuid() + Path.GetExtension(File.FileName);
                    File.SaveAs(Server.MapPath("/Document/File/TicketFile/" + MassageFile));

                    ticketRepository.SendMassage(TicketID, 1, Text, MassageFile, userRepository.UserByPhoneNumber(User.Identity.Name).UserID);

                    return Redirect("/User/Ticket/InnerTicket?ID=" + TicketID);

                }

            }
            else
            {
                ticketRepository.SendMassage(TicketID, 1, Text, null, userRepository.UserByPhoneNumber(User.Identity.Name).UserID);

                return Redirect("/User/Ticket/InnerTicket?ID=" + TicketID);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TicketCategory = ticketRepository.ticketCategories().Where(t => t.IsActive == true);
            ViewBag.Order = userRepository.UserByPhoneNumber(User.Identity.Name).Orders.Select(o => o.PackageService);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTicketInUser createTicketInUser, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                if (createTicketInUser.TicketCategory == 0)
                {
                    ModelState.AddModelError("TicketCategory", "لطفا بخش مورد نظر را انتخاب کنید");
                    ViewBag.TicketCategory = ticketRepository.ticketCategories().Where(t => t.IsActive == true);
                    ViewBag.Order = userRepository.UserByPhoneNumber(User.Identity.Name).Orders.Select(o => o.PackageService);

                    return View();
                }
                else
                {
                    if (createTicketInUser.order == 0)
                    {
                        ModelState.AddModelError("Order", "لطفا سرویس مورد نظر  را انتخاب کنید");
                        ViewBag.TicketCategory = ticketRepository.ticketCategories().Where(t => t.IsActive == true);
                        ViewBag.Order = userRepository.UserByPhoneNumber(User.Identity.Name).Orders.Select(o => o.PackageService);
                        return View();
                    }
                    else
                    {

                        if (string.IsNullOrEmpty(createTicketInUser.Subject))
                        {
                            ModelState.AddModelError("Subject", "لطفا موضوع  مورد نظر  را وارد کنید");
                            ViewBag.TicketCategory = ticketRepository.ticketCategories().Where(t => t.IsActive == true);
                            ViewBag.Order = userRepository.UserByPhoneNumber(User.Identity.Name).Orders.Select(o => o.PackageService);
                            return View();
                        }
                        else
                        {

                            if (string.IsNullOrEmpty(createTicketInUser.Text))
                            {
                                ModelState.AddModelError("Text", "لطفا متن مورد نظر  را انتخاب کنید");
                                ViewBag.TicketCategory = ticketRepository.ticketCategories().Where(t => t.IsActive == true);
                                ViewBag.Order = userRepository.UserByPhoneNumber(User.Identity.Name).Orders.Select(o => o.PackageService);
                                return View();
                            }
                            else
                            {

                                if (File != null)
                                {
                                    if (File.ContentLength > 3000000)
                                    {
                                        ModelState.AddModelError("File", "حجم فایل بیش از 3 مگابایت میباشد");
                                        ViewBag.TicketCategory = ticketRepository.ticketCategories().Where(t => t.IsActive == true);
                                        ViewBag.Order = userRepository.UserByPhoneNumber(User.Identity.Name).Orders.Select(o => o.PackageService);
                                        return View();
                                    }
                                    else
                                    {
                                        if (File.ContentType != "application/pdf" && File.ContentType != "image/jpg" && File.ContentType != "image/png" && File.ContentType != "image/jpeg")
                                        {
                                            ModelState.AddModelError("File", "تنها فایل ها با فرمت pdf و png و jpeg قابل ارسال میباشد");
                                            ViewBag.TicketCategory = ticketRepository.ticketCategories().Where(t => t.IsActive == true);
                                            ViewBag.Order = userRepository.UserByPhoneNumber(User.Identity.Name).Orders.Select(o => o.PackageService);
                                            return View();
                                        }
                                        else
                                        {
                                            createTicketInUser.File = Guid.NewGuid() + Path.GetExtension(File.FileName);
                                            File.SaveAs(Server.MapPath("/Document/File/TicketFile/" + createTicketInUser.File));

                                            createTicketInUser.user = userRepository.UserByPhoneNumber(User.Identity.Name);
                                            ticketRepository.CreateTicketInUser(createTicketInUser);
                                            return Redirect("/User/Ticket");
                                        }
                                    }
                                }
                                else
                                {
                                    createTicketInUser.user = userRepository.UserByPhoneNumber(User.Identity.Name);
                                    createTicketInUser.File = null;
                                    ticketRepository.CreateTicketInUser(createTicketInUser);
                                    return Redirect("/User/Ticket");
                                }
                            }
                        }
                    }
                }

            }
            ViewBag.TicketCategory = ticketRepository.ticketCategories().Where(t => t.IsActive == true);
            ViewBag.Order = userRepository.UserByPhoneNumber(User.Identity.Name).Orders.Select(o => o.PackageService);
            return View(createTicketInUser);
        }
    }
}