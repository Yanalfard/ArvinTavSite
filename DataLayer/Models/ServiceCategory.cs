﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
    public class ServiceCategory
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "والد")]
        public int? ParentID { get; set; }

        [Display(Name = "متن")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Display(Name = "فعال بودن")]
        public bool IsActive { get; set; }

        [Display(Name = "توضیح")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }

        public virtual List<PackageService> PackageServices { get; set; }

        public virtual List<Spider> Spiders { get; set; }


        public ServiceCategory()
        {

        }
    }
}
