using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class ChildCategoryViewModel
    {
        public int ParentID { get; set; }

        public string ParentTitle { get; set; }

        public IEnumerable<ServiceCategory> ChildCategories { get; set; }
    }
}
