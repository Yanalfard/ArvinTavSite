using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "متن مشتری")]
        public string Title { get; set; }

        [Display(Name = "شماره تماس")]
        public string PhoneNumber { get; set; }

        [Display(Name = "لوگو")]
        public string Logo { get; set; }
    }
}
