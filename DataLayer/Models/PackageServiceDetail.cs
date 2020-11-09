using System;
using System.Collections.Generic;
<<<<<<< HEAD

=======
>>>>>>> 5a943b0ca43ae54c17807f00b086e5fb9aa6ea2d
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
