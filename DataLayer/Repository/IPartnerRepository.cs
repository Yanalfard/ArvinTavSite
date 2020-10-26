using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPartnerRepository:IDisposable
    {
        IEnumerable<Partner> Allpartners();

        Partner partnerById(int ID);

        string CreatePartner(string Title, string PhoneNumber, string Logo);

        string EditPartner(int ID,string Title, string PhoneNumber, string Logo);

        string RemovePartner(int ID);

        void Save();
    }
}
