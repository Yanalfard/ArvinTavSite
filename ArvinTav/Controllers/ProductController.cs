using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Controllers
{
    public class ProductController : Controller
    {
        private ArvinContext db = new ArvinContext();
        private IServiceCategoryRepository serviceCategoryRepository;
        private IPackageRepository packageRepository;

        public ProductController()
        {
            serviceCategoryRepository = new ServiceCategoryRepository(db);
            packageRepository = new PackageRepository(db);

        }


        // GET: Product
        [Route("MainPackage/{ID}/{Title}")]
        public ActionResult ProductsByMainCategory(int ID)
        {
            PackageByMainCategoryViewModel PackageByMainCategoryViewModel = new PackageByMainCategoryViewModel();
            PackageByMainCategoryViewModel.ServiceCategory = serviceCategoryRepository.AllChildCategory(ID, true);

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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                serviceCategoryRepository.Dispose();
                packageRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}