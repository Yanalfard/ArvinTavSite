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
                db.DomainServices.Remove(DomainByID(ID));
                Save();
                return "true";
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

    }
}
