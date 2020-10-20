using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using DataLayer;

namespace ArvinTav.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection login)
        {
            if (GoogleRechapchaControl.ControlRechapcha(login) == "true")
            {
                // go ahead and write code to validate username password against database
                var phonNumber = login["PhoneNumber"].ToString();
                var passWord = login["PassWord"].ToString();

                if (phonNumber == "" || passWord == "" || phonNumber.Length < 11 || phonNumber.Length > 15 || passWord.Length < 5)
                {
                    ModelState.AddModelError("PhoneNumber", "اطلاعات وارد شده نادرست است");
                }


                string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(passWord, "SHA256");
                
                return View();
            }
            else
            {
                ViewBag.Message = "لطفا گزینه من ربات نیستم را تایید کنید";
                return View();
            }

        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(FormCollection Register)
        {
            if (GoogleRechapchaControl.ControlRechapcha(Register) == "true")
            {
                // go ahead and write code to validate username password against database
                var phonNumber = Register["PhoneNumber"].ToString();
                var passWord = Register["PassWord"].ToString();

                if (phonNumber == "" || passWord == "" || phonNumber.Length < 11 || phonNumber.Length > 15 || passWord.Length < 5)
                {
                    ModelState.AddModelError("PhoneNumber", "اطلاعات وارد شده نادرست است");
                }

                string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(passWord, "SHA256");
                
                return View();
            }
            else
            {
                ViewBag.Message = "لطفا گزینه من ربات نیستم را تایید کنید";
                return View();
            }

        }

        [HttpGet]
        public ActionResult Active(User user)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Active(User user, int ActiveCode)
        {
            return View();
        }
    }
}