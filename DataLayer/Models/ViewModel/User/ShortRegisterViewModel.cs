using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
   public class ShortRegisterViewModel
    {
        [Display(Name = "شماره تماس")]
        [MinLength(11, ErrorMessage = "{0} معتبر نیست")]
        [MaxLength(15, ErrorMessage = "{0} معتبر نیست")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [Display(Name = "رمز عبور")]
        [MinLength(5, ErrorMessage = "لطفا کارکتر های بیشتری وارد کنید")]
        [MaxLength(30, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        
        [Display(Name = "کد احراز هویت")]
        [MaxLength(5, ErrorMessage = "کد نا معتبر")]
        [MinLength(5, ErrorMessage = "کد نا معتبر")]
        public string AuthenticationCode { get; set; }
    }
}
