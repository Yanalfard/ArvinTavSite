using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Massage
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500, ErrorMessage = "لطفا کارکتر های کمتری وارد کنید")]
        public string Text { get; set; }

        public bool Seen { get; set; }

        public virtual User User { get; set; }

        public Massage()
        {

        }
    }
}
