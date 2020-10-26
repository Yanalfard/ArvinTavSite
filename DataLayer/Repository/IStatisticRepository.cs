using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface IStatisticRepository:IDisposable
    {
        StatisticViewModel Allstatistic();

        RevenuesViewModel AllRevenues();

        OrderExplorerViewModel AllOrderExplorer();

        TicketExplorerViewModel TicketExplorer();


    }
}
