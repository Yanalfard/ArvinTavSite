﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class Slider
    {
        public int ID { get; set; }

        [MaxLength(900)]
        [MinLength(2)]
        public string Title { get; set; }

        
        
        public string Link { get; set; }

        public string Image { get; set; }


    }
}
