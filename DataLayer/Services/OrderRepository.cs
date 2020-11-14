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

        public IEnumerable<Order> AllOrderForUser(int UserID)
        {
            return db.Orders.Where(o => o.User.UserID == UserID);
        }

        public string SwitchingStatus(int ID)
        {
            try
            {
                Order order = OrderById(ID);
                if (order.Status == 1)
                {
                    order.Status = 4;
                    Save();
                    return "true";
                }
                else if (order.Status == 2)
                {
                    order.Status = 3;
                    Save();
                    return "true";
                }
                return "false";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public Order OrderById(int ID)
        {
            return db.Orders.Find(ID);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
