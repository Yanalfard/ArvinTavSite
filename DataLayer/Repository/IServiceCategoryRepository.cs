using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IServiceCategoryRepository
    {
        IEnumerable<ServiceCategory> AllMainServiceCategory(bool View);

        ChildCategoryViewModel AllChildCategory(int ParentID, bool View);

        ServiceCategory ServiceCategoryById(int ID);

        string AddServiceCategory(int ParentID, string Title,int IsActive, string Description, string Image);

        string EditServiceCategory(int ID, string Title, int IsActive, string Description, string Image);

        string RemoveServiceCategory(int ID);

        string IsActive(int ID);

        void Save();
    }
}
