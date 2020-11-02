using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Partner
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "متن همکار")]
        [MaxLength(100)]
        [MinLength(2)]
        public string Title { get; set; }

        [Display(Name = "شماره تماس")]
        [MaxLength(15)]
        [MinLength(11)]
        public string PhoneNumber { get; set; }

        [Display(Name = "لوگو")]
        public string Logo { get; set; }
    }
}
