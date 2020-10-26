using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class UserEditInAdminViewModel
    {
        public User user { get; set; }

        public IEnumerable<UserRole> userRoles { get; set; }
    }
}
