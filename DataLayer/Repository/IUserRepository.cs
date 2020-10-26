using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IUserRepository:IDisposable
    {
        IEnumerable<User> AllUser();

        User UserById(int ID);

        User UserByPhoneNumber(string PhoneNumber);

        IEnumerable<UserRole> AllRoles();

        string Edit(int ID, string FullName, string Brand, string Email, int UserRole);

        UserRole RoleById(int RoleID);

        void Save();


    }
}
