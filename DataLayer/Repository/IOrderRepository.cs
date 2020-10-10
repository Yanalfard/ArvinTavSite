using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IOrderRepository:IDisposable
    {
        IEnumerable<Order> AllOrders();

        Order OrderById(int ID);

        string SwitchingStatus(int ID);

        OrderDetailViewModel GetOrderDetail(int ID);
    }
}
