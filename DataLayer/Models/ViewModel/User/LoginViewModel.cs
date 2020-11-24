using System.ComponentModel.DataAnnotations;
namespace DataLayer
{
    public class LoginViewModel
    {
        [Display(Name = "شماره تماس")]
        [MinLength(11, ErrorMessage = "{0} معتبر نیست")]
        [MaxLength(15, ErrorMessage = "{0} معتبر نیست")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} معتبر نیست")]
        public string PhoneNumber { get; set; }


        [Display(Name = "رمز عبور")]
        [MinLength(5, ErrorMessage = "لطفا کارکتر های بیشتری وارد کنید")]
        [MaxLength(30, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }

    }
}
