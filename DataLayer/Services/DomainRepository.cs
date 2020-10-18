using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DomainRepository : IDomainRepository
    {
        private ArvinContext db;
        private IServiceCategoryRepository ServiceCategoryRepository;

        public DomainRepository(ArvinContext context)
        {
            this.db = context;
            ServiceCategoryRepository = new ServiceCategoryRepository(db);
        }

        public IEnumerable<DomainService> AllDomain(bool View)
        {
            if (View == false)
            {
                return db.DomainServices;
            }
            else
            {
                return db.DomainServices.Where(d => d.IsActive == true);
            }
        }

        public string AddDomianService(int Category, string Suffix, int IsActive, string Price)
        {
            try
            {
                if (db.DomainServices.Any(d => d.Suffix == Suffix))
                {
                    return "repetitive";
                }
                else
                {
                    DomainService domainService = new DomainService();

                    domainService.ServiceCategory = ServiceCategoryRepository.ServiceCategoryById(Category);
                    domainService.Suffix = Suffix;
                    if (IsActive == 1)
                    {
                        domainService.IsActive = true;
                    }
                    if (IsActive == 0)
                    {
                        domainService.IsActive = false;
                    }
                    domainService.Price = Price;
                    db.DomainServices.Add(domainService);
                    Product product = new Product();
                    product.SideID = 2;
                    product.ServiceCategory = domainService.ServiceCategory;
                    product.DomainService = domainService;
                    product.HostingService = null;
                    product.PackageService = null;
                    db.products.Add(product);
                    Save();
                    return "true";
                }
            }
            catch (Exception ex)
            {

                return "Erorr :" + ex.Message;
            }
        }

        public DomainService DomainByID(int ID)
        {
            return db.DomainServices.Find(ID);
        }

        public string EditDomainService(int ID, int Category, string Suffix, int IsActive, string Price)
        {
            try
            {
                DomainService domainService = DomainByID(ID);
                domainService.ServiceCategory = ServiceCategoryRepository.ServiceCategoryById(Category);
                domainService.Suffix = Suffix;
                if (IsActive == 1)
                {
                    domainService.IsActive = true;
                }
                else if (IsActive == 0)
                {
                    domainService.IsActive = false;
                }
                domainService.Price = Price;
                Save();

                return "true";
            }
            catch (Exception ex)
            {

                return "Error :" + ex.Message;
            }
        }

        public string RemoveDomain(int ID)
        {
            
            try
            {
                IEnumerable<DomainServiceOrder> domainServiceOrders = db.domainServiceOrders.Where(dso => dso.DomainService.ID == ID);
                Product product = db.products.Where(p => p.SideID == 2 && p.DomainService.ID == ID).Single();

                if (domainServiceOrders.Count() == 0)
                {
                    db.products.Remove(product);
                    db.DomainServices.Remove(DomainByID(ID));
                    Save();
                    return "true";
                }
                else
                {
                    db.domainServiceOrders.RemoveRange(domainServiceOrders);
                    db.products.Remove(product);
                    db.DomainServices.Remove(DomainByID(ID));
                    Save();
                    return "true";
                }

                
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public string StatusDomain(int ID)
        {
            try
            {
                DomainService domainService = DomainByID(ID);
                if (domainService.IsActive == true)
                {
                    domainService.IsActive = false;
                    Save();
                    return "true";
                }
                else
                {
                    domainService.IsActive = true;
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
