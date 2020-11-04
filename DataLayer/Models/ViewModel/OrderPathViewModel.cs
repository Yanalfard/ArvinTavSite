using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderPathViewModel
    {
        public int? HostingServiceID { get; set; }

        public int? DomainServiceID { get; set; }

        public int? PackageServiceID { get; set; }
    }
}
