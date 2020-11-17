using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Database : IDatabase
    {
        public ArvinContext _db() => new ArvinContext();
    }
}
