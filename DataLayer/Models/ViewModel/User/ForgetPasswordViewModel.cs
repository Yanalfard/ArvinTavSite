using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ForgetPasswordViewModel
    {
        public string EndPhoneNumber { get; set; }

        public string AuthenticationCode { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
