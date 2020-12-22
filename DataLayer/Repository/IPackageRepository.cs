using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPackageRepository : IDisposable
    {
        IEnumerable<PackageService> AllPackageServices();

        PackageService PackageServiceById(int ID);

        IEnumerable<PackageServiceDetail> AllPackageServicesDetails(int ID);

        int Create(int Category, string Title, string Price, string Image, string Description);

        string CreatePackageServiceDetails(List<PackageServiceDetails> details);

        string Edit(int ID, int Category, string Title, string Price, string Image, string Description);

        void Save();
    }
}
