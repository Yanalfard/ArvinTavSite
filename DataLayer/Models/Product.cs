using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "سمت : 1:هاستینگ 2:دامنه 3:بسته های نرم افزاری")]
        public int SideID { get; set; }

        [Display(Name = "دسته بندی")]
        public virtual ServiceCategory ServiceCategory { get; set; }

        [Display(Name = "سرویس هاستینگ")]
        public virtual HostingService HostingService { get; set; }

        [Display(Name = "سرویس دامنه")]
        public virtual DomainService DomainService { get; set; }

        [Display(Name = "سرویس بسته ی نرم افزاری")]
        public virtual PackageService PackageService { get; set; }

        public Product()
        {

        }

    }
}
