﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Spider
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "نام")]
        public string Title { get; set; }

        [Display(Name = "متن")]
        public string Description { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }
        
        public virtual List<SeoTage> SeoTages { get; set; }

        public Spider()
        {

        }
    }
}