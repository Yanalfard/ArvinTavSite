using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDomainRepository
    {
        IEnumerable<DomainService> AllDomain(bool View);

        string AddDomianService(int Category, string Suffix, int IsActive, string Price);

        DomainService DomainByID(int ID);

        string EditDomainService(int ID, int Category, string Suffix, int IsActive, string Price);

        string RemoveDomain(int ID);

        string StatusDomain(int ID);

        void Save();
    }
}
