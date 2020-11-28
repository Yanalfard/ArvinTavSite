using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SearchViewModel
    {
        public List<PackageService> packageServices { get; set; }

        public List<Spider> spiders { get; set; }
    }
}
