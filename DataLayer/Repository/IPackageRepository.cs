using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPackageRepository
    {
        IEnumerable<PackageService> AllPackageServices();

        PackageService PackageServiceById(int ID);
    }
}
