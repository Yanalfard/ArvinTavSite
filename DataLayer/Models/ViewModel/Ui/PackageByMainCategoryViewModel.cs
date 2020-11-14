using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PackageByMainCategoryViewModel
    {
        public ChildCategoryViewModel ServiceCategory { get; set; }

        public IEnumerable<PackageService> packageServices { get; set; }
    }
}
