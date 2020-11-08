using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
=======
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
>>>>>>> e95ac9428777e79799560c444417fe806898421c
using System.Threading.Tasks;

namespace DataLayer
{
   public class PackageServiceDetail
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "متن")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Display(Name = "پاسخ")]
        [MaxLength(100)]
        public string Response { get; set; }

        public virtual PackageService PackageService { get; set; }

        public PackageServiceDetail()
        {

        }
    }
}
