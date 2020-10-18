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

        [Display(Name = "شماره تماس")]
        [MinLength(10, ErrorMessage = "{0} معتبر نیست")]
        [MaxLength(15, ErrorMessage = "{0} معتبر نیست")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "نام کامل")]
        [MinLength(3, ErrorMessage = "لطفا کارکتر های بیشتری وارد کنید")]
        [MaxLength(30, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "نام تجاری")]
        [MaxLength(300, ErrorMessage = "نام با کارکتر های کمتری وارد کنید")]
        [MinLength(2, ErrorMessage = "نام با کارکتر های بیشتری وارد کنید")]
        public string Brand { get; set; }

        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress, ErrorMessage = "ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }


        [Display(Name = "رمز عبور")]
        [MinLength(5, ErrorMessage = "لطفا کارکتر های بیشتری وارد کنید")]
        [MaxLength(30, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Display(Name = "تایید رمز عبور")]
        [MinLength(5, ErrorMessage = "لطفا کارکتر های بیشتری وارد کنید")]
        [MaxLength(30, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string ConfirmPassWord { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        [DataType(DataType.DateTime)]
        public DateTime SignUpTime { get; set; }

        [Display(Name = "تاریخ آخرین ورود")]
        [DataType(DataType.DateTime)]
        public DateTime FinalLoginTime { get; set; }

        [Display(Name = "دسترسی")]
        public virtual UserRole UserRole { get; set; }

        [Display(Name = "سفارشات")]
        public virtual List<Order> Orders { get; set; }

        public virtual List<HostingOrder> HostingOrders { get; set; }

        public List<Ticket> tickets { get; set; }

        public List<InnerTicket> innerTickets { get; set; }

        public List<MarketerReport> marketerReports { get; set; }

        public User()
        {

        }
    }
}
