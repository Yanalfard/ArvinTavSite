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
        private IUserRepository userRepository;
        private ArvinContext db = new ArvinContext();
        public AccountController()
        {
            userRepository = new UserRepository(db);

        }

        // GET: Account

        //Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginView, FormCollection login, string ReturnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                if (GoogleRechapchaControl.ControlRechapcha(login) == "true")
                {
                    if (userRepository.CheckUser(loginView.PhoneNumber, Security.Cryptography(loginView.PassWord)) == true)
                    {
                        FormsAuthentication.SetAuthCookie(loginView.PhoneNumber, loginView.RememberMe);
                        userRepository.UserByPhoneNumber(loginView.PhoneNumber).FinalLoginTime = DateTime.Now;
                        userRepository.Save();
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("PhoneNumber", "این حساب وجود ندارد.");
                    }
                }
                else
                {
                    ViewBag.Message = "لطفا گزینه من ربات نیستم را تایید کنید";
                    return View();
                }
            }
            return View(loginView);
        }
        

        //Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerView, FormCollection Register)
        {
            if (ModelState.IsValid)
            {
                registerView.PhoneNumber.Replace(" ", "");
                if (registerView.PassWord != registerView.ConfirmPassWord)
                {
                    ModelState.AddModelError("ConfirmPassWord", "لطفا رمز عبور را تایید کنید");
                }
                if (GoogleRechapchaControl.ControlRechapcha(Register) == "true")
                {
                    if (registerView.PhoneNumber.StartsWith("0") == false)
                    {
                        ModelState.AddModelError("PhoneNumber", "شماره تماس باید از صفر شروع شود");
                    }
                    else
                    {
                        if (userRepository.CheckPhoneNumber(registerView.PhoneNumber))
                        {
                            ModelState.AddModelError("PhoneNumber", "شماره تماس قبلا ثبت شده است");
                        }
                        else
                        {
                            //Create Sms Code
                            var CodeCreator = Guid.NewGuid().ToString();
                            string Code = CodeCreator.Substring(CodeCreator.Length - 5);

                            // Create User
                            ShortRegisterViewModel shortRegisterViewModel = new ShortRegisterViewModel();
                            shortRegisterViewModel.PhoneNumber = registerView.PhoneNumber;
                            shortRegisterViewModel.PassWord = Security.Cryptography(registerView.PassWord);
                            shortRegisterViewModel.AuthenticationCode = Security.Cryptography(Code);
                            if (userRepository.ShortRegister(shortRegisterViewModel) == true)
                            {
                                //Send Code In Sms
                                var Text = $"به آروین تاو خوش آمدید \n کد شما : {Code}";
                                Sms.RegisterAcoount(registerView.PhoneNumber, Text);

                                // Redirect To Active
                                AccountActiveViewModel accountActiveViewModel = new AccountActiveViewModel();
                                accountActiveViewModel.PhoneNumber = registerView.PhoneNumber;
                                accountActiveViewModel.DateTime = DateTime.Now;
                                return RedirectToAction("Active", accountActiveViewModel);
                            }
                        }
                    }
                }
                else
                {
                    ViewBag.Message = "لطفا گزینه من ربات نیستم را تایید کنید";
                    return View();
                }
            }
            return View(registerView);
        }


        //Active Account
        [HttpGet]
        public ActionResult Active(AccountActiveViewModel accountActiveViewModel)
        {
            return View(accountActiveViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Active(PushAccountActiveViewModel pushAccountActiveViewModel)
        {
            pushAccountActiveViewModel.ActiveCode = Security.Cryptography(pushAccountActiveViewModel.ActiveCode);
            DateTime RequestTimeActiveUser = pushAccountActiveViewModel.DateTime.AddMinutes(5);
            if (DateTime.Now > RequestTimeActiveUser)
            {
                ViewBag.Massage = "زمان فعالسازی حساب شما منقضی شده است. سیستم حساب شما را پاک کرده است.";
                userRepository.RemoveUser(userRepository.UserByPhoneNumber(pushAccountActiveViewModel.PhoneNumber));
                return View();
            }
            else
            {
                userRepository.ActiveAccount(pushAccountActiveViewModel);
                return RedirectToAction("SuccessAccount");
            }
        }


        //Success
        [HttpGet]
        public ActionResult Success(string Massage)
        {
            return View();
        }

        //Forget Password

        [HttpGet]
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgetPassword(string PhoneNumber, FormCollection form)
        {

            if (GoogleRechapchaControl.ControlRechapcha(form) == "true")
            {
                if (userRepository.UserByPhoneNumber(PhoneNumber) != null)
                {
                    //Create Sms Code
                    var CodeCreator = Guid.NewGuid().ToString();
                    string Code = CodeCreator.Substring(CodeCreator.Length - 8);

                    if (userRepository.ForgetAccount(PhoneNumber, Security.Cryptography(Code)) == true)
                    {
                        string PhoneNumberStr = PhoneNumber;
                        string End4NumberPhoneNumber = PhoneNumberStr.Substring(PhoneNumberStr.Length - 5);
                        string ForgetLink = "http://arvintavco.com/Account/Forget/" + End4NumberPhoneNumber + "-" + Code;
                        //Send Code In Sms
                        var Text = $"جهت بازیابی رمز عبور روی لینک زیر کلیک کنید \n لینک شما : \n {ForgetLink}";
                        Sms.ForgetAcoount(PhoneNumber, Text);

                        return RedirectToAction("ForgetPasswordSuccess");
                    }
                    else
                    {
                        ViewBag.Massage = "شما به تازگی درخواست تغییر پسورد کرده اید لطفا کمی صبر کنید";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Massage = "حسابی با این شماره تماس وجود ندارد";
                    return View();
                }
            }
            else
            {
                ViewBag.MessageGoogle = "لطفا گزینه من ربات نیستم را تایید کنید";
                return View();
            }

        }

        //ForgetPasswordSuccess
        public ActionResult ForgetPasswordSuccess()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            return View();
        }

        [Route("Account/Forget/{EndPhoneNumber}-{Code}")]
        [HttpGet]
        public ActionResult PushForgetPassword(string EndPhoneNumber, string Code)
        {
            ViewBag.endph = EndPhoneNumber;
            ViewBag.co = Code;
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PushForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel, FormCollection form)
        {
            if (GoogleRechapchaControl.ControlRechapcha(form) == "true")
            {
                if (forgetPasswordViewModel.Password != forgetPasswordViewModel.ConfirmPassword)
                {
                    ViewBag.Massage = "تایید رمز عبور را صحیح وارد کنید";
                    return View();
                }
                else
                {
                    DateTime dateTime = userRepository.UserByAuthenticationCode(Security.Cryptography(forgetPasswordViewModel.AuthenticationCode)).ForgetTime.AddMinutes(10);
                    if (DateTime.Now > dateTime)
                    {
                        ViewBag.Massage = "زمان استفاده از تغییر رمز برای شما منقضی شده است";
                        return View();
                    }
                    else
                    {
                        forgetPasswordViewModel.Password = Security.Cryptography(forgetPasswordViewModel.Password);
                        forgetPasswordViewModel.AuthenticationCode = Security.Cryptography(forgetPasswordViewModel.AuthenticationCode);
                        if (userRepository.ForgetAccountPush(forgetPasswordViewModel) == true)
                        {
                            return Redirect("/Account/Login");
                        }
                    }
                }
            }
            else
            {
                ViewBag.MessageGoogle = "لطفا گزینه من ربات نیستم را تایید کنید";
            }
            return View();
        }


        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return Redirect("/");
        }
    }
}