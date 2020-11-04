using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ChildCategoryINViewViewmodel
    {
        public ServiceCategory ServiceCategory { get; set; }

        public IEnumerable<ServiceCategory> serviceCategories { get; set; }
    }
}
