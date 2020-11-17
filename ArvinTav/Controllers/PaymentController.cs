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


        public ActionResult Pay(int ID, string OffCode)
        {
            PackageService package = packageRepository.PackageServiceById(ID);
            Order order = new Order();

            if (OffCode != null && OffCode != "")
            {

                Discount discount = festivalRepository.DiscountByCode(OffCode);


                if (discount != null)
                {
                    order.Price = (package.Price * discount.Percentage) / 100;
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

            order.Price = package.Price;
            order.DateTime = DateTime.Now;
            order.PackageService = packageRepository.PackageServiceById(ID);
            order.Status = 1;
            order.User = userRepository.UserByPhoneNumber(User.Identity.Name);
            System.Net.ServicePointManager.Expect100Continue = false;
            ZarinTest.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinTest.PaymentGatewayImplementationServicePortTypeClient();
            string Authority;
            int OrderID = orderRepository.Create(order);
            int Status = zp.PaymentRequest("YOUR-ZARINPAL-MERCHANT-CODE", order.Price, "شرکت ایده پردازان آروین تاو", "info@arvintav.com", "09145016607", "http://localhost:54170/Home/Verify/" + OrderID, out Authority);



            if (Status == 100)
            {
                // return Redirect("https://www.zarinpal.com/pg/StartPay/" + Authority);

                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + Authority);
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
                    ZarinTest.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinTest.PaymentGatewayImplementationServicePortTypeClient();

                    int Status = zp.PaymentVerification("YOUR-ZARINPAL-MERCHANT-CODE", Request.QueryString["Authority"].ToString(), Amount, out RefID);

                    if (Status == 100)
                    {
                        Response.Write("Success!! RefId: " + RefID);
                    }
                    else
                    {
                        Response.Write("Error!! Status: " + Status);
                    }

                }
                else
                {
                    Response.Write("Error! Authority: " + Request.QueryString["Authority"].ToString() + " Status: " + Request.QueryString["Status"].ToString());
                }
            }
            else
            {
                Response.Write("Invalid Input");
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