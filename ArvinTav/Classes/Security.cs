using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ArvinTav
{
    public class Security
    {
        public static string Cryptography(string Parameter)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(Parameter, "SHA256");
        }
    }
}