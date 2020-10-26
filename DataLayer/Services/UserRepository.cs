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

        public User UserById(int ID)
        {
            return db.Users.Find(ID);
        }

        public User UserByPhoneNumber(string PhoneNumber)
        {
            return db.Users.Where(u => u.PhoneNumber == PhoneNumber).SingleOrDefault();
        }

        public string Edit(int ID, string FullName, string Brand, string Email, int UserRole)
        {
            try
            {
                User user = UserById(ID);
                user.FullName = FullName;
                user.Brand = Brand;
                user.Email = Email;
                user.UserRole = RoleById(UserRole);
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }

        }

        public IEnumerable<UserRole> AllRoles()
        {
            return db.UserRoles;
        }

        public UserRole RoleById(int RoleID)
        {
            return db.UserRoles.Find(RoleID);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
