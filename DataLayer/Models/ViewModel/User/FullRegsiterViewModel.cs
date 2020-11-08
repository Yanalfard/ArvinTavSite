using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DataLaye
{
    public class FullRegsiterViewModel
    {
        [Display(Name = "نام کامل")]
        [MaxLength(30, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "نام تجاری")]
        [MaxLength(30, ErrorMessage = "نام با کارکتر های کمتری وارد کنید")]
        public string Brand { get; set; }

        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress, ErrorMessage = "ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }


    }
}
