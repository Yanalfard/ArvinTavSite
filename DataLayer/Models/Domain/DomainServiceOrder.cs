using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DomainServiceOrder
    {
        [Key]
        public int ID { get; set; }
        
        [Display(Name = "نام دامنه")]
        [MaxLength(200,ErrorMessage ="نام دامنه صحیح نیست")]
        [MinLength(2,ErrorMessage ="نام دامنه صحیح نیست")]
        public string DomainName { get; set; }

        public virtual DomainService DomainService { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }

        public DomainServiceOrder()
        {

        }
    }
}
