using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MarketerReport
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public bool Status { get; set; }

        public virtual User User { get; set; }

        public MarketerReport()
        {

        }

    }
}
