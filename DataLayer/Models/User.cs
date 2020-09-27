using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public int RoleID { get; set; }

        [Display(Name = "شماره تماس")]
        [MinLength(10, ErrorMessage = "لطفا کارکتر های بیشتری وارد کنید")]
        [MaxLength(15, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نام کامل")]
        [MinLength(3, ErrorMessage = "لطفا کارکتر های بیشتری وارد کنید")]
        [MaxLength(30, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "رمز عبور")]
        [MinLength(5, ErrorMessage = "لطفا کارکتر های بیشتری وارد کنید")]
        [MaxLength(30, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PassWord { get; set; }

        [Display(Name = "تایید رمز عبور")]
        [MinLength(5, ErrorMessage = "لطفا کارکتر های بیشتری وارد کنید")]
        [MaxLength(30, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ConfirmPassWord { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime SignUpTime { get; set; }

        [Display(Name = "تاریخ آخرین ورود")]
        public DateTime FinalLoginTime { get; set; }

        [Display(Name = "دسترسی")]
        public virtual UserRole UserRole { get; set; }

        public virtual List<Order> Orders { get; set; }

        public User()
        {

        }
    }
}
