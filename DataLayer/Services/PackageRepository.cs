using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PackageRepository : IPackageRepository
    {
        private ArvinContext db;

        public PackageRepository(ArvinContext context)
        {
            this.db = context;
        }
        public IEnumerable<PackageService> AllPackageServices()
        {
            return db.PackageServices;
        }

        public PackageService PackageServiceById(int ID)
        {
            return db.PackageServices.Find(ID);
        }
    }
}
