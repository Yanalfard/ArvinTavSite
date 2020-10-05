using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HostingEditViewModel
    {
        public IEnumerable<ServiceCategory> AllMainServiceCatgory { get; set; }

        public HostingService HostingService { get; set; }
    }
}
