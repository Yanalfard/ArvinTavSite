using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TicketCategory
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "متن")]
        public string Title { get; set; }

        [Display(Name = "فعال بودن")]
        public bool IsActive { get; set; }
        
        public TicketCategory()
        {

        }
    }
}
