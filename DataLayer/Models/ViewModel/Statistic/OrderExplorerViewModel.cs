using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderExplorerViewModel
    {
        public int AllOrderCount { get; set; }

        public int AllWaitingPayOrderCount { get; set; }

        public int AllPaidOrderCount { get; set; }

        public int AllNotEndedOrderCount { get; set; }

        public int AllEndedOrderCount{get;set; }
    }
}
