using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderDetails
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "متن")]
        public string Title { get; set; }
        
        [Display(Name ="نام دسته بندی")]
        public string CategoryName { get; set; }

        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [Display(Name = "سفارش")]
        public virtual Order Order { get; set; }

        public OrderDetails()
        {

        }
    }
}
