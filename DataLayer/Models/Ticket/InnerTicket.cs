using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class InnerTicket
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "متن")]
        public string Text { get; set; }

        [Display(Name = "فایل")]
        public string File { get; set; }

        [Display(Name = "از طرف")]
        public int? SideID { get; set; }

        [Display(Name = "زمان")]
        public DateTime dateTime { get; set; }

        [Display(Name = "مربوط به تیکت")]
        public virtual Ticket Ticket { get; set; }

        [Display(Name ="کاربر")]
        public virtual User User { get; set; }

        public InnerTicket()
        {

        }
    }
}
