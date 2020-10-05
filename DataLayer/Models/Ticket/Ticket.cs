using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Ticket
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "موضوع")]
        public string Subject { get; set; }

        [Display(Name = "وضعیت: 1:بازنشده 2:خوانده شده 3:تکمیل نشده 4:تکمیل شده")]
        public int Status { get; set; }

        [Display(Name = "زمان")]
        public DateTime dateTime { get; set; }

        [Display(Name ="زمان تکمیل تیکت")]
        public DateTime EndTicketTime { get; set; }

        [Display(Name = "کاربر")]
        public virtual User User { get; set; }

        [Display(Name = "داخل تیکت")]
        public virtual List<InnerTicket> InnerTickets { get; set; }
        public Ticket()
        {

        }
    }
}
