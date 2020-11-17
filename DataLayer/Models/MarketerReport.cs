using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
    public class MarketerReport
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(600)]
        [AllowHtml]
        public string Description { get; set; }

        
        public bool Status { get; set; }

        public DateTime DateTime { get; set; }

        public virtual User User { get; set; }

        public MarketerReport()
        {

        }

    }
}
