using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Project
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "متن")]
        public string Title { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }

        [Display(Name = "لینک")]
        public string Link { get; set; }

        [Display(Name = "وضعیت: 1:در حال ساخت  2:تکمیل شده")]
        public int Status { get; set; }

        [Display(Name ="مشتری")]
        public virtual User User { get; set; }

        public Project()
        {

        }
    }
}
