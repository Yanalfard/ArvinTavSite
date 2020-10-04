using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IHostingRepository
    {
        IEnumerable<HostingService> AllhostingServices();

        IEnumerable<HostingServiceDetails> AllHostingDetails(int ID);

        HostingService HostingServiceById(int ID);

        HostingEditViewModel hostingEditViewModel(int ID);

        int Create(int Category, string Title, int FreeSSL, int Support, string Space, string MonthlyTraffic, string SitesBeHosted, string threeMonthsCost, string SixMonthsCost, string AnnuallyCost);

        string CreateHostingServiceDetails(List<HostingServiceDetailsViewModel> Details);

        int Edit(int ID, int Category, string Title, int FreeSSL, int Support, string Space, string MonthlyTraffic, string SitesBeHosted, string threeMonthsCost, string SixMonthsCost, string AnnuallyCost);

        string Remove(int ID);

        void Save();
    }
}
