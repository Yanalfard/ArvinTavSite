using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HostingService
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "متن")]
        [MaxLength(100)]
        [MinLength(2)]
        public string Title { get; set; }

        [Display(Name = "فضا")]
        [MaxLength(100)]
        [MinLength(2)]
        public string Space { get; set; }

        [Display(Name = "ترافیک ماهانه")]
        [MaxLength(100)]
        [MinLength(2)]
        public string Monthly_Traffic { get; set; }

        [Display(Name = "تعداد سایت قابل میزبانی")]
        [MaxLength(100)]
        [MinLength(2)]
        public string Sites_Be_Hosted { get; set; }

        [Display(Name = "SSL رایگان")]
        public bool FreeSSL { get; set; }

        [Display(Name = "پشتیبانی 24 ساعته")]
        public bool Support { get; set; }

        [Display(Name = "هزینه سه ماهه")]
        public int threeMonthsCost { get; set; }

        [Display(Name = "هزینه شش ماهه")]
        public int SixMonthsCost { get; set; }

        [Display(Name = "هزینه سالانه")]
        public int AnnuallyCost { get; set; }

        [Display(Name = "تعداد سفارش")]
        public int? OrderCount { get; set; }

        [Display(Name = "جزئیات")]
        public virtual List<HostingServiceDetails> HostingServiceDetails { get; set; }
        
        [Display(Name = "دسته بندی")]
        public virtual ServiceCategory ServiceCategory { get; set; }

        public virtual List<HostingOrder> HostingOrders { get; set; }

        public HostingService()
        {

        }
    }
}
