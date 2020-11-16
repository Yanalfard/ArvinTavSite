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

        IEnumerable<Order> AllOrderForUser(int UserID);

        Order OrderById(int ID);

        string SwitchingStatus(int ID);

        int Create(Order order);

        void Save();
        
    }
}
