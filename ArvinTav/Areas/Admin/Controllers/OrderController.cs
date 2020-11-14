using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
namespace ArvinTav.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,PartAdmin")]
    public class OrderController : Controller
    {
        private ArvinContext db = new ArvinContext();
        private IOrderRepository OrderRepository;

        public OrderController()
        {
            OrderRepository = new OrderRepository(db);
        }
        // GET: Admin/Order
        public ActionResult Index(int PageId = 1, int ID = 0, string PhoneNumber = "", int Status = 0, int InPageCount = 0)
        {
            if (ID == 0)
            {
                if (Status == 0)
                {
                    if (PhoneNumber == "")
                    {
                        if (InPageCount == 0)
                        {
                            int count = OrderRepository.AllOrders().Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            //Saerch

                            ViewBag.ID = null;

                            ViewBag.phoneNumber = "";

                            ViewBag.Status = 0;

                            //End Search

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            return View(OrderRepository.AllOrders().OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                        }
                        else
                        {
                            int count = OrderRepository.AllOrders().Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            //Saerch

                            ViewBag.ID = null;

                            ViewBag.phoneNumber = "";

                            ViewBag.Status = 0;

                            //End Search

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            return View(OrderRepository.AllOrders().OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                        }
                    }
                    else
                    {
                        if (InPageCount == 0)
                        {
                            int count = OrderRepository.AllOrders().Where(o => o.User.PhoneNumber == PhoneNumber).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            //Saerch

                            ViewBag.ID = null;

                            ViewBag.phoneNumber = PhoneNumber;

                            ViewBag.Status = 0;

                            //End Search

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            return View(OrderRepository.AllOrders().Where(o => o.User.PhoneNumber == PhoneNumber).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                        }
                        else
                        {
                            int count = OrderRepository.AllOrders().Where(o => o.User.PhoneNumber.Contains(PhoneNumber)).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            //Saerch

                            ViewBag.ID = null;

                            ViewBag.phoneNumber = PhoneNumber;

                            ViewBag.Status = 0;

                            //End Search

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            return View(OrderRepository.AllOrders().Where(o => o.User.PhoneNumber.Contains(PhoneNumber)).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                        }
                    }
                }
                else
                {
                    if (PhoneNumber == "")
                    {
                        if (InPageCount == 0)
                        {
                            int count = OrderRepository.AllOrders().Where(o => o.Status == Status).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            //Saerch

                            ViewBag.ID = "";

                            ViewBag.phoneNumber = "";

                            ViewBag.Status = Status;

                            //End Search

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            return View(OrderRepository.AllOrders().Where(o => o.Status == Status).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                        }
                        else
                        {
                            int count = OrderRepository.AllOrders().Where(o => o.Status == Status).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            //Saerch

                            ViewBag.ID = "";

                            ViewBag.phoneNumber = "";

                            ViewBag.Status = Status;

                            //End Search

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            return View(OrderRepository.AllOrders().Where(o => o.Status == Status).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                        }
                    }
                    else
                    {
                        if (InPageCount == 0)
                        {
                            int count = OrderRepository.AllOrders().Where(o => o.Status == Status && o.User.PhoneNumber.Contains(PhoneNumber)).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            //Saerch

                            ViewBag.ID = 0;

                            ViewBag.phoneNumber = PhoneNumber;

                            ViewBag.Status = Status;

                            //End Search

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            return View(OrderRepository.AllOrders().Where(o => o.Status == Status && o.User.PhoneNumber.Contains(PhoneNumber)).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                        }
                        else
                        {
                            int count = OrderRepository.AllOrders().Where(o => o.Status == Status && o.User.PhoneNumber.Contains(PhoneNumber)).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            //Saerch

                            ViewBag.ID = 0;

                            ViewBag.phoneNumber = PhoneNumber;

                            ViewBag.Status = Status;

                            //End Search

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            return View(OrderRepository.AllOrders().Where(o => o.Status == Status && o.User.PhoneNumber.Contains(PhoneNumber)).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                        }
                    }
                }
            }
            else
            {
                if (InPageCount == 0)
                {
                    int count = OrderRepository.AllOrders().Where(o => o.ID == ID).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    //Saerch

                    ViewBag.ID = ID;

                    ViewBag.phoneNumber = "";

                    ViewBag.Status = 0;

                    //End Search

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return View(OrderRepository.AllOrders().Where(o => o.ID == ID).Skip(skip).Take(18).ToList());
                }
                else
                {
                    int count = OrderRepository.AllOrders().Where(o => o.ID == ID).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    //Saerch

                    ViewBag.ID = ID;

                    ViewBag.phoneNumber = "";

                    ViewBag.Status = 0;

                    //End Search

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return View(OrderRepository.AllOrders().Where(o => o.ID == ID).Skip(skip).Take(InPageCount).ToList());
                }
            }
        }
        
        public string SwitchingStatus(int ID)
        {
            return OrderRepository.SwitchingStatus(ID);
        }

        public ActionResult P_Details(int ID)
        {
            return PartialView(OrderRepository.OrderById(ID));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                OrderRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}