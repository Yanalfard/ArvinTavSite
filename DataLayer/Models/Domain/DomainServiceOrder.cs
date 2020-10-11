﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DomainServiceOrder
    {
        [Key]
        public int ID { get; set; }
        
        [Display(Name = "نام دامنه")]
        public string DomainName { get; set; }

        public virtual DomainService DomainService { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }

        public DomainServiceOrder()
        {

        }
    }
}