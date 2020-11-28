using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class CreateTicketInUser
    {
        [Display(Name = "موضوع")]
        [MaxLength(100, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        [MinLength(5, ErrorMessage = "لطفا کارکتر های بیشتری وارد کنید")]
        [Required(ErrorMessage = "لطفا موضوع را وارد کنید")]
        public string Subject { get; set; }

        [Display(Name = "بخش مربوطه")]
        public int TicketCategory { get; set; }
        
        [Display(Name = "متن")]
        [MaxLength(600, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        [MinLength(5, ErrorMessage = "لطفا کارکتر های بیشتری وارد کنید")]
        [Required(ErrorMessage = "لطفا موضوع را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Display(Name = "فایل")]
        public string File { get; set; }

        [Display(Name ="سرویس")]

        public int order { get; set; }

        public User user { get; set; }
    }
}
