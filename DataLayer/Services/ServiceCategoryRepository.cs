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
                return db.ServiceCategories.Where(c => c.ParentID == null);
            }
            else
            {
                return db.ServiceCategories.Where(c => c.ParentID == null && c.IsActive == true);
            }
        }

        public ChildCategoryViewModel AllChildCategory(int ParentID, bool View)
        {
            ChildCategoryViewModel childCategoryViewModel = new ChildCategoryViewModel();
            if (View == false)
            {
                childCategoryViewModel.ParentID = ParentID;
                childCategoryViewModel.ParentTitle = ServiceCategoryById(ParentID).Title;
                childCategoryViewModel.ChildCategories = db.ServiceCategories.Where(c => c.ParentID == ParentID);
                return childCategoryViewModel;
            }
            else
            {
                childCategoryViewModel.ParentID = ParentID;
                childCategoryViewModel.ChildCategories = db.ServiceCategories.Where(c => c.ParentID == ParentID && c.IsActive == true);
                return childCategoryViewModel;
            }
        }

        public ServiceCategory ServiceCategoryById(int ID)
        {
            return db.ServiceCategories.Find(ID);
        }

        public string EditServiceCategory(int ID, string Title, int IsActive, string Description, string Image)
        {
            try
            {
                ServiceCategory serviceCategory = ServiceCategoryById(ID);
                if (string.IsNullOrEmpty(Image))
                {
                    serviceCategory.Title = Title;
                    if (IsActive == 1)
                    {
                        serviceCategory.IsActive = true;
                    }
                    else if (IsActive == 0)
                    {
                        serviceCategory.IsActive = false;
                    }
                    serviceCategory.Description = Description;
                    Save();
                    return "true";
                }
                else
                {

                    serviceCategory.Title = Title;
                    if (IsActive == 1)
                    {
                        serviceCategory.IsActive = true;
                    }
                    else if (IsActive == 0)
                    {
                        serviceCategory.IsActive = false;
                    }
                    serviceCategory.Description = Description;
                    serviceCategory.Image = Image;
                    Save();
                    return "true";
                }
            }
            catch (Exception ex)
            {
                return "Erorr" + ex.Message;
            }
        }

        public string AddServiceCategory(int ParentID, string Title, int IsActive, string Description, string Image)
        {
            try
            {
                ServiceCategory serviceCategory = new ServiceCategory();
                if (ParentID == 0)
                {
                    serviceCategory.ParentID = null;
                    serviceCategory.Title = Title;
                    if (IsActive == 1)
                    {
                        serviceCategory.IsActive = true;
                    }
                    else if (IsActive == 0)
                    {
                        serviceCategory.IsActive = false;
                    }
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
                    if (IsActive == 1)
                    {
                        serviceCategory.IsActive = true;
                    }
                    else if (IsActive == 0)
                    {
                        serviceCategory.IsActive = false;
                    }
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

        public string RemoveServiceCategory(int ID)
        {
            try
            {
                db.PackageServices.RemoveRange(db.PackageServices.Where(p => p.ServiceCategory.ID == ID));
                db.HostingServices.RemoveRange(db.HostingServices.Where(p => p.ServiceCategory.ID == ID));
                db.DomainServices.RemoveRange(db.DomainServices.Where(p => p.ServiceCategory.ID == ID));
                db.ServiceCategories.RemoveRange(db.ServiceCategories.Where(c => c.ParentID == ID));
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

        public string IsActive(int ID)
        {
            ServiceCategory serviceCategory = ServiceCategoryById(ID);

            if (serviceCategory.IsActive == true)
            {
                serviceCategory.IsActive = false;
                Save();
                return "true";
            }
            else
            {
                serviceCategory.IsActive = true;
                Save();
                return "true";
            }

        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
