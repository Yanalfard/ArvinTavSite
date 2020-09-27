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

        public IEnumerable<ServiceCategory> AllChildCategory(int ParentID, bool View)
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

        public ServiceCategory ServiceCategoryById(int ID)
        {
            return db.ServiceCategories.Find(ID);
        }
        
        public string EditServiceCategory(int ID, string Title, bool IsActive, string Description, string Image)
        {
            try
            {
                ServiceCategory serviceCategory = ServiceCategoryById(ID);
                serviceCategory.Title = Title;
                serviceCategory.IsActive = IsActive;
                serviceCategory.Description = Description;
                serviceCategory.Image = Image;
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr" + ex.Message;
            }
        }

        public string RemoveServiceCategory(int ID)
        {
            try
            {
                db.ServiceCategories.Remove(ServiceCategoryById(ID));
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

        public string AddServiceCategory(int ParentID, string Title, bool IsActive, string Description, string Image)
        {
            try
            {
                ServiceCategory serviceCategory = new ServiceCategory();
                if (ParentID == 0)
                {
                    serviceCategory.ParentID = null;
                    serviceCategory.Title = Title;
                    serviceCategory.IsActive = IsActive;
                    serviceCategory.Image = Image;
                    serviceCategory.Description = Description;
                    db.ServiceCategories.Add(serviceCategory);
                    Save();
                    return "true";
                }
                else
                {
                    serviceCategory.ParentID = ParentID;
                    serviceCategory.Title = Title;
                    serviceCategory.IsActive = IsActive;
                    serviceCategory.Image = Image;
                    serviceCategory.Description = Description;
                    db.ServiceCategories.Add(serviceCategory);
                    Save();
                    return "true";
                }
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.ToString();
            }
        }
    }
}
