using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Controllers
{
    public class HomeController : Controller
    {
        private ArvinContext db = new ArvinContext();

        private IServiceCategoryRepository serviceCategoryRepository;
        private IPackageRepository packageRepository;
        private ISpiderRepository spiderRepository;
        private IUserRepository userRepository;
        private IOrderRepository orderRepository;
        public HomeController()
        {
            serviceCategoryRepository = new ServiceCategoryRepository(db);
            packageRepository = new PackageRepository(db);
            spiderRepository = new SpiderRepository(db);
            userRepository = new UserRepository(db);
            orderRepository = new OrderRepository(db);
        }

        // GET: Home
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }


        //Start Partial Category
        public ActionResult P_MainCategory()
        {
            return PartialView(serviceCategoryRepository.AllMainServiceCategory(true));
        }

        public ActionResult P_MainCategoryMobile()
        {
            return PartialView(serviceCategoryRepository.AllMainServiceCategory(true));
        }

        public ActionResult P_ChildCategory(int ID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ID, true).ChildCategories);
        }

        public ActionResult P_ChildCategoryMobile(int ID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ID, true).ChildCategories);
        }

        public ActionResult P_SubCategoryMobile(int ID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ID, true).ChildCategories);
        }

        public ActionResult P_SubCategory(int ID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ID, true).ChildCategories);
        }
        //End Partial Category


        //Start Product Part

        [Route("MainPackage/{ID}/{Title}")]
        public ActionResult ProductsByMainCategory(int ID)
        {
            PackageByMainCategoryViewModel PackageByMainCategoryViewModel = new PackageByMainCategoryViewModel();
            PackageByMainCategoryViewModel.ServiceCategory = serviceCategoryRepository.AllChildCategory(ID, true);
            PackageByMainCategoryViewModel.packageServices = packageRepository.AllPackageServices().Where(p => p.ServiceCategory.ParentID == ID);

            return View(PackageByMainCategoryViewModel);
        }

        [Route("Products/{ID}/{Title}")]
        public ActionResult Products(int ID, string Title)
        {
            return View(serviceCategoryRepository.ServiceCategoryById(ID).PackageServices);
        }

        [Route("Product/{ID}/{Title}")]
        public ActionResult Product(int ID, string Title)
        {
            return View(packageRepository.PackageServiceById(ID));
        }

        [Route("Payment/{ID}")]
        public ActionResult Payment(int ID)
        {
            return View(packageRepository.PackageServiceById(ID));
        }

        public ActionResult PaymentPay(int ID)
        {
            PackageService package = packageRepository.PackageServiceById(ID);

            Order order = new Order();
            order.DateTime = DateTime.Now;
            order.PackageService = packageRepository.PackageServiceById(ID);
            order.Status = 1;
            order.User = userRepository.UserByPhoneNumber(User.Identity.Name);
            order.Price = package.Price;
            System.Net.ServicePointManager.Expect100Continue = false;
            ZarinTest.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinTest.PaymentGatewayImplementationServicePortTypeClient();
            string Authority;

            int Status = zp.PaymentRequest("YOUR-ZARINPAL-MERCHANT-CODE", order.Price, "شرکت ایده پردازان آروین تاو", "info@arvintav.com", "09145016607", "http://localhost:54170/Home/Verify/" + orderRepository.Create(order), out Authority);



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

        //End Product Part

        //Start Spider Part

        [Route("Blog")]
        public ActionResult Blog(int PageId = 1, string Result = "", int InPageCount = 0)
        {
            if (Result == "")
            {
                if (InPageCount == 0)
                {
                    int count = spiderRepository.AllSpider().Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return View(spiderRepository.AllSpider().OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = spiderRepository.AllSpider().Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return View(spiderRepository.AllSpider().OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                }
            }
            else
            {
                if (InPageCount == 0)
                {
                    int count = spiderRepository.AllSpider().Where(s => s.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return View(spiderRepository.AllSpider().Where(s => s.Title.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = spiderRepository.AllSpider().Where(s => s.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return View(spiderRepository.AllSpider().Where(s => s.Title.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                }
            }
        }

        [Route("Post/{ID}/{Title}")]
        public ActionResult Post(int ID, string Title)
        {
            return View(spiderRepository.SpiderById(ID));
        }
        //End Spider Part

        [Route("AboutUs")]
        public ActionResult AboutUs()
        {
            return View();
        }

        [Route("ContactUs")]
        [HttpPost]
        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(Massage massage)
        {
            var t = massage;
            return View();
        }

    }
}