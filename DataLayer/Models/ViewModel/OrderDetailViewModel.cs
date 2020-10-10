using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderDetailViewModel
    {
       public Order Order { get; set; }

       public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
