﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class DomainService
    {
        [Key]
        public int ID { get; set; }
        
        [Display(Name ="پسوند")]
        public string Suffix { get; set; }

        [Display(Name ="قیمت")]
        public int Price { get; set; }

        [Display(Name ="فعال بودن")]
        public bool IsActive { get; set; }

        public virtual ServiceCategory ServiceCategory { get; set; }
        
        public virtual List<Order> Orders { get; set; }
        public DomainService()
        {

        }
    }
}
