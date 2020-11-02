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

        public bool ShortRegister(ShortRegisterViewModel shortRegisterViewModel)
        {

            User user = new User();
            user.PhoneNumber = shortRegisterViewModel.PhoneNumber;
            user.PassWord = shortRegisterViewModel.PassWord;
            user.AuthenticationCode = shortRegisterViewModel.AuthenticationCode;
            user.Active = false;
            user.SignUpTime = DateTime.Now;
            user.FinalLoginTime = DateTime.Now;
            user.RegisterActiveTime = DateTime.Now;
            user.ForgetTime = DateTime.Now;
            user.UserRole = RoleById(5);
            db.Users.Add(user);
            Save();
            return true;


            //catch (Exception)
            //{
            //    return false;
            //}
        }

        public User UserById(int ID)
        {
            return db.Users.Find(ID);
        }

        public User UserByPhoneNumber(string PhoneNumber)
        {
            return db.Users.Where(u => u.PhoneNumber == PhoneNumber).SingleOrDefault();
        }

        public User UserByAuthenticationCode(string AuthenticationCode)
        {
            return db.Users.Where(u => u.AuthenticationCode == AuthenticationCode).SingleOrDefault();
        }

        public void RemoveUser(User user)
        {
            db.Users.Remove(user);
        }

        public bool CheckPhoneNumber(string PhoneNumber)
        {
            return db.Users.Any(u => u.PhoneNumber == PhoneNumber);
        }

        public bool CheckUser(string PhoneNumber, string Password)
        {
            return db.Users.Any(u => u.PhoneNumber == PhoneNumber && u.PassWord == Password && u.Active == true);
        }

        public bool ActiveAccount(PushAccountActiveViewModel PushAccountActiveViewModel)
        {
            User user = UserByPhoneNumber(PushAccountActiveViewModel.PhoneNumber);
            if (user.AuthenticationCode == PushAccountActiveViewModel.ActiveCode)
            {
                user.Active = true;
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ForgetAccount(string PhoneNumber, string AuthenticationCode)
        {
            User user = UserByPhoneNumber(PhoneNumber);
            user.AuthenticationCode = AuthenticationCode;
            user.ForgetTime = DateTime.Now;
            if (user.ForgetTime == null)
            {
                Save();
                return true;
            }
            else
            {
                if (user.ForgetTime.AddMinutes(10) > DateTime.Now)
                {
                    return false;
                }
                else
                {
                    Save();
                    return true;
                }
            }


        }

        public bool ForgetAccountPush(ForgetPasswordViewModel ForgetPasswordViewModel)
        {
            User user = UserByAuthenticationCode(ForgetPasswordViewModel.AuthenticationCode);
            user.PassWord = ForgetPasswordViewModel.Password;
            Save();
            return true;
        }

        public string EditInAdmin(int ID, string FullName, string Brand, string Email, int UserRole)
        {
            try
            {
                User user = UserById(ID);
                if (user.FullName == "")
                {
                    user.FullName = null;
                }
                else
                {
                    user.FullName = FullName;
                }
                if (user.Brand == "")
                {
                    user.Brand = null;
                }
                else
                {
                    user.Brand = Brand;
                }
                if (user.Email == "")
                {
                    user.Email = null;
                }
                else
                {
                    user.Email = Email;
                }
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
