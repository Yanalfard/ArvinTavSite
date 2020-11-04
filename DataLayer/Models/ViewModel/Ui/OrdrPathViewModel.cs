using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrdrPathViewModel
    {
        public HostingService HostingService { get; set; }

        public int PeriodOfService { get; set; }

        public DomainService DomainService { get; set; }

        public string DomainName { get; set; }

        public PackageService PackageService { get; set; }
    }
}
