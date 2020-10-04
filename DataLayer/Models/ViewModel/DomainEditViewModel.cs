using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DomainEditViewModel
    {
        public IEnumerable<ServiceCategory> serviceCategories { get; set; }

        public DomainService DomainService { get; set; }
    }
}
