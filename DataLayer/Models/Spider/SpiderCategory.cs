using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SpiderCategory
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "متن دسته")]
        [MaxLength(100)]
        public string Title { get; set; }

        public List<Spider> spiders { get; set; }

        public SpiderCategory()
        {

        }
    }
}
