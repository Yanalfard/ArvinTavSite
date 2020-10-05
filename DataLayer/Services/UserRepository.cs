using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserRepository : IUserRepository
    {
        private ArvinContext db;

        public UserRepository(ArvinContext context)
        {
            this.db = context;
        }
        public IEnumerable<User> AllUser()
        {
            return db.Users;
        }
    }
}
