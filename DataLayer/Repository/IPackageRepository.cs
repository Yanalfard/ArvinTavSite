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

        string Create(int Category, string Title, string Price, string Image, string Description);

        string Edit(int ID, int Category, string Title, string Price, string Image, string Description);

        string Remove(int ID);

        void Save();
    }
}
