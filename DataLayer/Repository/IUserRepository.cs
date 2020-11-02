using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> AllUser();

        bool ShortRegister(ShortRegisterViewModel shortRegisterViewModel);

        User UserById(int ID);

        User UserByPhoneNumber(string PhoneNumber);

        User UserByAuthenticationCode(string AuthenticationCode);

        void RemoveUser(User user);

        bool CheckPhoneNumber(string PhoneNumber);

        bool ActiveAccount(PushAccountActiveViewModel PushAccountActiveViewModel);

        bool ForgetAccount(string PhoneNumber, string AuthenticationCode);

        bool ForgetAccountPush(ForgetPasswordViewModel ForgetPasswordViewModel);

        bool CheckUser(string PhoneNumber,string Password);

        IEnumerable<UserRole> AllRoles();

        string EditInAdmin(int ID, string FullName, string Brand, string Email, int UserRole);

        UserRole RoleById(int RoleID);

        void Save();


    }
}
