using System;
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

        [Display(Name = "جمع سفارش")]
        public int Price { get; set; }

        [Display(Name = "وضعیت = 1:منتظر پرداخت - 2:پرداخت شده - 3:تکمیل شده - 4:لغو شده")]
        public int Status { get; set; }

        [Display(Name = "توضیحات سفارش")]
        [MaxLength(600, ErrorMessage = "توضیحات کوتاه تری وارد کنید")]
        [MinLength(2)]
        public string Description { get; set; }

        [Display(Name = "زمان ثبت")]
        public DateTime DateTime { get; set; }

        [Display(Name = "کاربر")]
        public virtual User User { get; set; }

        public virtual PackageService PackageService { get; set; }

        public Order()
        {

        }
    }
}
