using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PackageRepository : IPackageRepository
    {
        private ArvinContext db;
        private IServiceCategoryRepository CategoryRepository;

        public PackageRepository(ArvinContext context)
        {
            this.db = context;
            CategoryRepository = new ServiceCategoryRepository(db);
        }

        public IEnumerable<PackageService> AllPackageServices()
        {
            return db.PackageServices;
        }

        public string Create(int Category, string Title, string Price, string Image, string Description)
        {
            try
            {
                PackageService packageService = new PackageService();
                packageService.ServiceCategory = CategoryRepository.ServiceCategoryById(Category);
                packageService.Title = Title;
                packageService.Price = Price;
                packageService.Image = Image;
                packageService.Description = Description;
                db.PackageServices.Add(packageService);
                Product product = new Product();
                product.SideID = 3;
                product.ServiceCategory = packageService.ServiceCategory;
                product.DomainService = null;
                product.HostingService = null;
                product.PackageService = packageService;
                db.products.Add(product);
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public string Edit(int ID, int Category, string Title, string Price, string Image, string Description)
        {
            try
            {
                PackageService packageService = PackageServiceById(ID);
                packageService.ServiceCategory = CategoryRepository.ServiceCategoryById(Category);
                packageService.Title = Title;
                packageService.Price = Price;
                if (Image != "")
                {
                    packageService.Image = Image;
                }
                packageService.Description = Description;
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public PackageService PackageServiceById(int ID)
        {
            return db.PackageServices.Find(ID);
        }

        public string Remove(int ID)
        {
            try
            {
                IEnumerable<OrderDetails> orderDetails = db.OrderDetails.Where(od => od.SideID == 3 && od.PackageService.ID == ID);

                if (orderDetails.Count() == 0)
                {
                    db.PackageServices.Remove(PackageServiceById(ID));
                    Save();
                    return "true";
                }
                else
                {
                    db.OrderDetails.RemoveRange(orderDetails);
                    db.PackageServices.Remove(PackageServiceById(ID));
                    Save();
                    return "true";
                }

            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
