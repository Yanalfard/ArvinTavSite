using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
    public class Spider
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "نام")]
        [MaxLength(100)]
        [DataType(DataType.MultilineText)]
        public string Title { get; set; }

        [Display(Name = "متن")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime DateTime { get; set; }

        public virtual SpiderCategory SpiderCategory { get; set; }

        public virtual List<SeoTage> SeoTages { get; set; }

        public Spider()
        {

        }
    }
}
