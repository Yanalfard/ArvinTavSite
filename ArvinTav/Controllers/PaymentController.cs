using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private ArvinContext db = new ArvinContext();
        private IPackageRepository packageRepository;
        private IUserRepository userRepository;
        private IOrderRepository orderRepository;
        private IFestivalRepository festivalRepository;

        public PaymentController()
        {

            packageRepository = new PackageRepository(db);
            userRepository = new UserRepository(db);
            orderRepository = new OrderRepository(db);
            festivalRepository = new FestivalRepository(db);

        }

        // GET: Payment
        [Route("PaymentSuccses/{ID}")]
        public ActionResult PaymentSuccses(int ID)
        {
            return View(packageRepository.PackageServiceById(ID));
        }


        public ActionResult Pay(int ID, string OffCode, string Description)
        {
            PackageService package = packageRepository.PackageServiceById(ID);
            Order order = new Order();
            order.Price = package.Price;

            if (OffCode != null && OffCode != "")
            {

                Discount discount = festivalRepository.DiscountByCode(OffCode);


                if (discount != null)
                {
                    int OFF = (order.Price * discount.Percentage) / 100;
                    order.Price = order.Price - OFF;
                }
                else
                {
                    order.Price = package.Price;
                }
            }
            else
            {
                order.Price = package.Price;
            }

            if (userRepository.UserByPhoneNumber(User.Identity.Name).Orders.Where(o => o.PackageService.ID == package.ID).Count() > 0)
            {
                db.Orders.RemoveRange(userRepository.UserByPhoneNumber(User.Identity.Name).Orders.Where(o => o.PackageService.ID == package.ID));
                orderRepository.Save();
            }

            order.Description = Description;
            order.DateTime = DateTime.Now;
            order.PackageService = packageRepository.PackageServiceById(ID);
            order.Status = 1;
            order.User = userRepository.UserByPhoneNumber(User.Identity.Name);
            System.Net.ServicePointManager.Expect100Continue = false;
            ZarinPal.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinPal.PaymentGatewayImplementationServicePortTypeClient();
            string Authority;
            int OrderID = orderRepository.Create(order);
            int Status = zp.PaymentRequest("b066bea5-78e5-4355-9b8d-dff85c8fdb40", order.Price, "شرکت ایده پرداز آروین تاو", "info@arvintav.com", "09145016607", "https://arvintavco.com/Payment/Verify/" + OrderID, out Authority);



            if (Status == 100)
            {
                return Redirect("https://www.zarinpal.com/pg/StartPay/" + Authority);

            }
            else
            {
                ViewBag.Error = "Error : " + Status;
                return RedirectToAction("Verify");

            }
        }

        public ActionResult Verify(int ID)
        {
            if (Request.QueryString["Status"] != "" && Request.QueryString["Status"] != null && Request.QueryString["Authority"] != "" && Request.QueryString["Authority"] != null)
            {
                if (Request.QueryString["Status"].ToString().Equals("OK"))
                {
                    int Amount = orderRepository.OrderById(ID).Price;
                    long RefID;
                    System.Net.ServicePointManager.Expect100Continue = false;
                    ZarinPal.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinPal.PaymentGatewayImplementationServicePortTypeClient();

                    int Status = zp.PaymentVerification("b066bea5-78e5-4355-9b8d-dff85c8fdb40", Request.QueryString["Authority"].ToString(), Amount, out RefID);

                    if (Status == 100)
                    {
                        Order Order = orderRepository.OrderById(ID);
                        Order.Status = 2;
                        orderRepository.Save();

                        //Send Code In Sms
                        var Text = Order.ID.ToString();
                        Sms.SendSms(Order.User.PhoneNumber, Text, "OrderCode");

                        ViewBag.OrderID = ID;
                        ViewBag.RefID = RefID;
                    }
                    else
                    {
                        ViewBag.Erorr = "پرداخت شما نا موفق بود. چنانچه مبلغ از حساب شما کسر شده باشد و خدمات برای شما ارائه داده نشده است مبلغ طی 24 ساعت به حساب شما بازگشت داده میشود";
                    }

                }
                else
                {
                    ViewBag.Erorr = "پرداخت شما نا موفق بود. چنانچه مبلغ از حساب شما کسر شده باشد و خدمات برای شما ارائه داده نشده است مبلغ طی 24 ساعت به حساب شما بازگشت داده میشود";
                }
            }
            else
            {
                ViewBag.Erorr = "پرداخت شما نا موفق بود. چنانچه مبلغ از حساب شما کسر شده باشد و خدمات برای شما ارائه داده نشده است مبلغ طی 24 ساعت به حساب شما بازگشت داده میشود";
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                packageRepository.Dispose();
                userRepository.Dispose();
                orderRepository.Dispose();
                festivalRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}