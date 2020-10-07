using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PackageEditViewModel
    {
        public IEnumerable<ServiceCategory> AllMainServiceCatgory { get; set; }

        public PackageService PackageService { get; set; }
    }
}
