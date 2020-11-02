using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HostingOrder
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "زمان انقضاء هاست : 1:سه ماه 2:شش ماه 3:یکسال")]
        public int ExpirationHostSide { get; set; }
        
        [Display(Name ="نام دامنه")]
        [MaxLength(200, ErrorMessage = "نام دامنه صحیح نیست")]
        [MinLength(2, ErrorMessage = "نام دامنه صحیح نیست")]
        public string DomainName { get; set; }

        [Display(Name ="دامنه")]
        public virtual DomainService DomainService { get; set; }

        public virtual HostingService HostingService { get; set; }

        public virtual User User { get; set; }

        public HostingOrder()
        {

        }
        
    }
}
