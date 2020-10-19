using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IMarketerRepository:IDisposable
    {
        IEnumerable<MarketerReport> AllMarketerReports();

        IEnumerable<MarketerReport> AllMarketerReportByMarketer(int UserID);

        MarketerReport MarketerReportById(int ID);

        string RemoveReport(int ID);

        string ChangeStatus(int ID);

        void Save();
    }
}
