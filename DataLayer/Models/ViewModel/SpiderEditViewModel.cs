using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class SpiderEditViewModel
    {
        public Spider Spider { get; set; }

        public IEnumerable<ServiceCategory> serviceCategories { get; set; }
    }
}
