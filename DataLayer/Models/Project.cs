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
        [MaxLength(100)]
        [MinLength(2)]
        public string Title { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }

        [Display(Name = "لینک")]
        [MaxLength(900)]
        [MinLength(2)]
        public string Link { get; set; }

        [Display(Name = "وضعیت: 1:در حال ساخت  2:تکمیل شده")]
        public int Status { get; set; }

        public Project()
        {

        }
    }
}
