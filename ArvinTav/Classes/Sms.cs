using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArvinTav
{
    public class Sms
    {
        public static bool SendSms(string PhonNumber, string Massage, string Temp)
        {

            var receptor = PhonNumber;
            var message = Massage;
            var api = new Kavenegar.KavenegarApi("4D4B66616C686B64534544333856706F7A6A35793647497735395A79496C59485644345257546C615137303D");
            api.VerifyLookup(receptor, Massage, Temp);
            api.VerifyLookup(receptor, "hello", "verifecation");

            return true;
        }
    }
}