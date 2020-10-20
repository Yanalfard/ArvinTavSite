using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ArvinTav
{
    public static class GoogleRechapchaControl
    {
        public static string ControlRechapcha(FormCollection form)
        {
            string urlToPost = "https://www.google.com/recaptcha/api/siteverify";
            string secretKey = "6LeiCdkZAAAAAD-C8UquFmyZlgCP3U6Xt0yk3jLc"; // change this
            string gRecaptchaResponse = form["g-recaptcha-response"];

            var postData = "secret=" + secretKey + "&response=" + gRecaptchaResponse;

            // send post data
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToPost);
            request.Method = "POST";
            request.ContentLength = postData.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(postData);
            }

            // receive the response now
            string result = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }

            // validate the response from Google reCaptcha
            var captChaesponse = JsonConvert.DeserializeObject<GoogleRechapcha>(result);
            if (!captChaesponse.Success)
            {
                return "false";
            }

            return "true";
        }
    }
}