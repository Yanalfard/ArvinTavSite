using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PackageService
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "متن")]
        [MaxLength(100)]
        [MinLength(2)]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(600)]
        [MinLength(2)]
        public string Description { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }

        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [Display(Name = "تعداد سفارش")]
        public int? OrderCount { get; set; }

        public virtual ServiceCategory ServiceCategory { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }
        
        public PackageService()
        {

        }
    }
}
