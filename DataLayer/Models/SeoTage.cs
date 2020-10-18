using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SeoTage
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "سمت : 1:بلاگ 2:صفحات فروش")]
        public int SideID { get; set; }

        public string Tage { get; set; }

        public virtual Spider Spider { get; set; }

        public virtual ServiceCategory ServiceCategory { get; set; }

        public SeoTage()
        {

        }
    }
}
