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

        public IEnumerable<PackageServiceDetail> AllPackageServicesDetails(int ID)
        {
            return db.packageServiceDetails.Where(psd => psd.PackageService.ID == ID);
        }

        public int Create(int Category, string Title, string Price, string Image, string Description)
        {
            try
            {
                PackageService packageService = new PackageService();
                packageService.ServiceCategory = CategoryRepository.ServiceCategoryById(Category);
                packageService.Title = Title;
                packageService.Price = Convert.ToInt32(Price.Replace(",", ""));
                packageService.Image = Image;
                packageService.Description = Description;
                db.PackageServices.Add(packageService);
                Save();
                return packageService.ID;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public string CreatePackageServiceDetails(List<PackageServiceDetails> details)
        {
            if (details == null)
            {
                return "true";
            }
            if (AllPackageServicesDetails(details.FirstOrDefault().PackageID).Count() > 0)
            {
                db.packageServiceDetails.RemoveRange(AllPackageServicesDetails(details.FirstOrDefault().PackageID));
                Save();
            }

            foreach (var item in details)
            {
                PackageServiceDetail packageServiceDetail = new PackageServiceDetail();
                packageServiceDetail.PackageService = PackageServiceById(item.PackageID);
                packageServiceDetail.Title = item.Title;
                packageServiceDetail.Response = item.Response;
                db.packageServiceDetails.Add(packageServiceDetail);
            }
            Save();
            return "true";
        }

        public string Edit(int ID, int Category, string Title, string Price, string Image, string Description)
        {
            try
            {
                PackageService packageService = PackageServiceById(ID);
                packageService.ServiceCategory = CategoryRepository.ServiceCategoryById(Category);
                packageService.Title = Title;
                packageService.Price = Convert.ToInt32(Price.Replace(",", ""));
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
                foreach (var item in PackageServiceById(ID).Tickets)
                {
                    db.InnerTickets.RemoveRange(item.InnerTickets);
                }
                db.packageServiceDetails.RemoveRange(PackageServiceById(ID).PackageServiceDetails);
                db.tickets.RemoveRange(PackageServiceById(ID).Tickets);
                db.Orders.RemoveRange(PackageServiceById(ID).Orders);
                db.PackageServices.Remove(PackageServiceById(ID));
                Save();
                return "true";

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
