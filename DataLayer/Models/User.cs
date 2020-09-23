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
        public int ID { get; set; } 

        [Display(Name = "شماره تماس")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نام کامل")]
        public string FullName { get; set; }

        [Display(Name = "دسترسی")]
        public Role Role { get; set; }

        public User()
        {

        }
    }
}
