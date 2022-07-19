using _98market.Core.ExtentionMethod;
using _98market.Core.Service;
using _98market.Core.Service.Interface;
using _98market.Core.Viewmodel;
using _98market.DataLayer.Entities;
using _98market.DataLayer.Entities.Entitieproduct;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _98market.Core;
using static _98market.Core.ExtentionMethod.RenderEmail;

namespace _98market.Controllers
{
    public class AccountController : Controller
    {
        private IUserservice _Userservice;
        private IViewRenderService _RenderEmail;
        public AccountController(IUserservice Userservice, IViewRenderService RenderEmail)
        {
            _Userservice = Userservice;
            _RenderEmail = RenderEmail;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisteMobilerViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_Userservice.ExistMobile(model.Mobile) == true)//چک می کنیم آیا موبایل قبلا در سیستم ثبت شده یا خیر
                {
                    ModelState.AddModelError("Mobile", "این موبایل قبلا در سیستم ثبت شده است");
                    return View();
                }
                _Userservice.RegisterUser(model);
                return RedirectToAction("ActiveUser", 
                    new { mobile = model.Mobile , 
                     CreateAccount = DateTime.Now,
                    });
            }
            return View();
        }

        public IActionResult ActiveUser(string mobile)
        {
            ActiveCodeViewModel model = new ActiveCodeViewModel()
            {
                Mobile = mobile,
            };
            return View();
        }


        [HttpPost]
        public IActionResult ActiveUser(ActiveCodeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_Userservice.ActiveCodeTrue(model) == false)
                {
                    ModelState.AddModelError("ActiveCode", "کد فعالسازی وارد شده نادرست است");
                    return View();
                }
                else
                {
                    var active = _Userservice.ActiveUser(model);//بررسی می کنیم آیا کاربر  کد را صحیح وارد کرده یا خیر
                    if (active != null)
                    {
                    

                        var claim = new List<Claim>
                                {
                                    new Claim("userid",active.userid.ToString()),
                                    new Claim("useraccount",active.userAccount),
                                    new Claim("useremail",active.phone),
                                };
                        var option = new AuthenticationProperties
                        {
                            IsPersistent = true,
                        };
                        HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claim, "Coockies")), option);
                        return View("Welcome",model.Mobile);
                    }
                }
            
               
            }
            return View();
        }

        public IActionResult LoginMobile(string mobile)
        {
            ActiveCodeViewModel model = new ActiveCodeViewModel()
            {
                Mobile = mobile,
            };
            return View();
        }

        [HttpPost]
        public IActionResult LoginMobile(LoginMobileViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool existmobile = _Userservice.ExistMobile(model.Mobile);//بررسی می کنیم موبایل وارد شده قبل ثبت نام کرده یا خیر
                if (existmobile == true)
                {
                    //ارسال اس ام اس 
                    _Userservice.SendSMSForLogin(model);
                    return RedirectToAction("ActiveUser", new { mobile = model.Mobile });
                }
                else
                {
                    ModelState.AddModelError("Mobile", "شما ثبت نام نکرده اید ابتدا ثبت نام کنید");

                }
            }
            return View();
        }


       



       //[HttpGet]
       //public IActionResult Register()
       //{
       //    return View();
       //}

       //[HttpPost]
       //public IActionResult Register(RegisterViewmodel model)
       //{
       //    if (!ModelState.IsValid)
       //    {
       //        return View(model);
       //    }

       //    var email = "";
       //    var mobile = "";
       //    var checkEmail = CheckEmail.IsValidEmail(model.PhoneOrEmail);
       //    if (checkEmail)
       //    {
       //        email = model.PhoneOrEmail.Trim().ToLower();
       //        if (_Userservice.ExistEmail(model.PhoneOrEmail ,0))
       //        {
       //            ModelState.AddModelError("email", "کاربری با این ایمیل قبلا ثبت نام کرده است .");
       //            return View(model);
       //        }
       //    }
       //    else
       //    {
       //        mobile = model.PhoneOrEmail.ToEnglishNumber().Trim();
       //        if (_Userservice.ExistPhone(model.PhoneOrEmail))
       //        {
       //            ModelState.AddModelError("email", "کاربری با این شماره موبایل قبلا ثبت نام کرده است .");
       //            return View(model);
       //        }

       //    }


       //    //if (_Userservice.ExistEmail(model.email, 0))
       //    //{
       //    //    ModelState.AddModelError("email", "کاربری با این ایمیل قبلا ثبت نام کرده است .");
       //    //    return View(model);
       //    //}
       //    user user = new user
       //    {
       //        CreateAccount = DateTime.Now,
       //        email = email,
       //        phone = mobile,
       //        isActive = false,
       //        IsDelete = false,
       //        password = model.password.EncodePasswordMd5(),
       //        userAccount = model.accountname,
       //        ActiveCode = GeneratCode.GuidCode()
       //    };
       //    int userid = _Userservice.AddUser(user);
       //    if (userid > 0)
       //    {
       //        var renderView = _RenderEmail.RenderToStringAsync("_EmaiAcive", user);
       //        bool ok = sendEmail.Send(user.email, "فعال سازی", renderView);
       //        return View("Welcome", user.email);
       //    }
       //    return View(model);
       //}


       //[Route("Account/ActiveAccount/{userid}/{Code}")]
       // public IActionResult ActiveAccount(int userid, string Code)
       // {
       //     user user = _Userservice.Finduser(userid, Code);

       //     if (user == null)
       //     {
       //         return NotFound();
       //     }
       //     user.isActive = true;
       //     user.ActiveCode = GeneratCode.GuidCode();
       //     _Userservice.updateuser(user);
       //     return RedirectToAction("Index", "Home");
       // }


        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult ForgotPassword(ForgotPasswordViewmodel model)
        //{
        //    user user = _Userservice.FindUserbuyeEmail(model.Email);
        //    if (user == null)
        //    {
        //        ModelState.AddModelError("", "کاربری با این مشخصات ی افت نشد .");
        //        return View(model);
        //    }

        //    var renderView = _RenderEmail.RenderToStringAsync("_RecoveryPassword", user);
        //    sendEmail.Send(user.email, "باز یابی کلمه عبور", renderView);
        //    return View("recoveryMassage", user.email);
        //}

        //[Route("Account/Recovery/{userid}/{Code}")]
        //public IActionResult Recovery(int userid, string Code)
        //{
        //    user user = _Userservice.Finduser(userid, Code);

        //    ForgotPasswordViewmodel viewmodel = new ForgotPasswordViewmodel
        //    {
        //        userid = user.userid,
        //        Email = user.email,
        //    };

        //    if (user != null)
        //    {
        //        return View("Recovery", viewmodel);
        //    }
        //    return View();
        //}


        //[HttpPost]
        //[Route("Account/Recovery/{userid}/{Code}")]
        //public IActionResult Recovery(ForgotPasswordViewmodel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Recovery", model);
        //    }
        //    user user = _Userservice.FindUserbuyeEmail(model.Email);
        //    if (user != null)
        //    {
        //        user.ActiveCode = GeneratCode.GuidCode();
        //        user.password = model.Password.EncodePasswordMd5();
        //    };

        //    bool updateuser = _Userservice.updateuser(user);
        //    TempData["Result"] = updateuser ? "true" : "false";
        //    return View("Recovery");
        //}


        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Login(LoginViewmodel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    user user = _Userservice.LoginUser(model.email, model.Password.EncodePasswordMd5());

        //    if (user != null)
        //    {
        //        if (user.isActive)
        //        {
        //            var claim = new List<Claim>
        //            {
        //                new Claim("userid",user.userid.ToString()),
        //                new Claim("useraccount",user.userAccount),
        //                new Claim("useremail",user.email),
        //            };
        //            var option = new AuthenticationProperties
        //            {
        //                IsPersistent = model.Rememberme,
        //            };
        //            HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claim, "Coockies")), option);
        //            //sendEmail.sendsms("09179105907", "ورود به حساب کاربری **وبسایت فروشگاهی کالا مارکت**");
        //            return RedirectToAction("index", "Home");
                    
        //        }

        //        else
        //        {
        //            ModelState.AddModelError("Rememberme", "حساب کاربری شما فعال نمی باشد ");
        //            return View(model);
        //        }
        //    }

        //    ModelState.AddModelError("Rememberme", "کاربری با این مشخصات یافت نشد.");
        //    return View(model);
        //}

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        [Route("checkauthorize")]
        public IActionResult checkauthorize()
        {
            return Json(User.Identity.IsAuthenticated);
        }

    }
}
