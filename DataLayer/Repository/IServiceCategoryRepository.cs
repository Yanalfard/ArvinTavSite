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

        IEnumerable<ServiceCategory> AllChildCategory(int ParentID,bool View);
    }
}
