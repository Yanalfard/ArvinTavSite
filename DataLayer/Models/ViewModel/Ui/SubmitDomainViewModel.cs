using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SubmitDomainViewModel
    {
        public HostingService HostingService { get; set; }

        public int PeriodOfService { get; set; }

        public IEnumerable<DomainService> domainServices { get; set; }
    }
}
