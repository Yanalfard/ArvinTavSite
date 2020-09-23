using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Role
    {
        [Key]
        public int ID { get; set; } 

        [Display(Name = "متن دسترسی")]
        public string Title { get; set; }

        [Display(Name = "دسترسی")]
        public string Name { get; set; }

        [Display(Name = "کاربران")]
        public List<User> users { get; set; }

        public Role()
        {

        }
    }
}
