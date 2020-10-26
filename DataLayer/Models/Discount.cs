using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Discount
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "کد تخفیف")]
        public string Code { get; set; }

        [Display(Name = "درصد تخفیف")]
        public int Percentage { get; set; }
    }
}
