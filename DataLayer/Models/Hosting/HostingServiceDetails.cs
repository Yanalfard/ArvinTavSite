using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HostingServiceDetails
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "متن")]
        [MaxLength(100)]
        [MinLength(2)]
        public string Title { get; set; }

        [Display(Name = "پاسخ")]
        [MaxLength(100)]
        [MinLength(2)]
        public string Response { get; set; }

        [Display(Name = "موضوع = 1:سخت افزار 2:نرم افزار 3:بیشتر")]
        public int Kind { get; set; }

        [Display(Name = "هاست")]
        public virtual HostingService HostingService { get; set; }

        public HostingServiceDetails()
        {

        }
    }
}
