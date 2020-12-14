using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LandingViewModel
    {
        public IEnumerable<Project> projects { get; set; }

        public IEnumerable<Partner> partners { get; set; }

        public IEnumerable<PackageService> packageServices { get; set; }

        public IEnumerable<Slider> AllSlider { get; set; }
    }
}
