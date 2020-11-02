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

        [Display(Name = "قیمت")]
        [MaxLength(500)]
        [MinLength(2)]
        public int Price { get; set; }

        [Display(Name = " سمت : 1:میزبانی 2:بسته نرم افزاری 3:دامنه")]
        public int SideID { get; set; }

        [Display(Name = "سفارش")]
        public virtual Order Order { get; set; }

        public virtual HostingOrder HostingOrder { get; set; }

        public virtual PackageService PackageService { get; set; }

        public virtual DomainServiceOrder DomainServiceOrder { get; set; }

        [Display(Name = "تیکت ها")]
        public virtual List<Ticket> Tickets { get; set; }

        public OrderDetails()
        {

        }
    }
}
