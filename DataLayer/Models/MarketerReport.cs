using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MarketerReport
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        [MinLength(2)]
        public string Title { get; set; }

        [MaxLength(600)]
        [MinLength(2)]
        public string Description { get; set; }

        public bool Status { get; set; }

        public virtual User User { get; set; }

        public MarketerReport()
        {

        }

    }
}
