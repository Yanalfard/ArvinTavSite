using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IMassageRepository : IDisposable
    {
        IEnumerable<Massage> AllMasssages();

        IEnumerable<Massage> AllMassageByUser(int UserID);

        Massage massageById(int ID);

        bool CreateMassage(Massage massage);

        bool ConfirmMassage(int ID);

        bool RemoveMassage(int ID);

        void Save();


    }
}
