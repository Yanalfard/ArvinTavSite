using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Massage
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "نام کامل")]
        [MinLength(2, ErrorMessage = "لطفا نام صحیح وارد کنید")]
        [MaxLength(100, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [MinLength(3, ErrorMessage = "ایمیل معتبر وارد کنید")]
        [MaxLength(100, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        [EmailAddress(ErrorMessage ="لطفا ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "شماره تماس")]
        [MaxLength(11, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "متن پیغام")]
        [MaxLength(1000, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        public string Text { get; set; }

        [Display(Name = "وضعیت")]
        public bool Seen { get; set; }

        public Massage()
        {

        }
    }
}
