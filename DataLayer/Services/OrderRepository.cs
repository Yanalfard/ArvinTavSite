using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

    public class OrderRepository : IOrderRepository
    {
        private ArvinContext db;

        public OrderRepository(ArvinContext context)
        {
            this.db = context;
        }
        public IEnumerable<Order> AllOrders()
        {
            return db.Orders;
        }

        public Order OrderById(int ID)
        {
            return db.Orders.Find(ID);
        }
    }
}
