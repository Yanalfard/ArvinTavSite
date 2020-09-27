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

        public DomainRepository(ArvinContext context)
        {
            this.db = context;
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

        public DomainService DomainByID(int ID)
        {
            return db.DomainServices.Find(ID);
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
