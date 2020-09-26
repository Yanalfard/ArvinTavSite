using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ServiceCategoryRepository : IServiceCategoryRepository
    {
        private ArvinContext db;

        public ServiceCategoryRepository(ArvinContext context)
        {
            this.db = context;
        }
        public IEnumerable<ServiceCategory> AllMainServiceCategory(bool View)
        {
            if (View == false)
            {
                return db.ServiceCategories;
            }
            else
            {
                return db.ServiceCategories.Where(s => s.IsActive == true);
            }
        }

        public IEnumerable<ServiceCategory> AllChildCategory(int ParentID,bool View)
        {
            if (View == false)
            {
                return db.ServiceCategories.Where(c => c.ParentID == ParentID);
            }
            else
            {
                return db.ServiceCategories.Where(c => c.ParentID == ParentID && c.IsActive == true);
            }
        }

    }
}
