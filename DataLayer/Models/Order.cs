﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        
        [Display(Name ="جمع سفارش")]
        public int Price { get; set; }

        [Display(Name ="وضعیت")]
        public int Status { get; set; }

        [Display(Name ="کاربر")]
        public virtual User User { get; set; }

        [Display(Name = "جزئیات")]
        public virtual List<OrderDetails> OrderDetails { get; set; }

        public Order()
        {

        }
    }
}
