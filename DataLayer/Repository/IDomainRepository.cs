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

        DomainService DomainByID(int ID);

        string RemoveDomain(int ID);

        string StatusDomain(int ID);

        void Save();
    }
}
