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

        public OrderDetailViewModel GetOrderDetail(int ID)
        {
            OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel();

            orderDetailViewModel.Order = OrderById(ID);
            orderDetailViewModel.OrderDetails = db.OrderDetails.Where(o => o.Order.ID == ID);

            return orderDetailViewModel;
        }

        public string SwitchingStatus(int ID)
        {
            try
            {
                Order order = OrderById(ID);
                if (order.Status == 1)
                {
                    order.Status = 4;
                    return "true";
                }
                else
                {
                    order.Status = 3;
                    return "true";
                }
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
        
    }
}
