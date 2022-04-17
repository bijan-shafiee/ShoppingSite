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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewmodel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (_Userservice.ExistEmail(model.email, 0))
            {
                ModelState.AddModelError("email", "کاربری با این ایمیل قبلا ثبت نام کرده است .");
                return View(model);
            }
            user user = new user
            {
                CreateAccount = DateTime.Now,
                email = model.email,
                isActive = false,
                IsDelete = false,
                password = model.password.EncodePasswordMd5(),
                userAccount = model.accountname,
                ActiveCode = GeneratCode.GuidCode()
            };
            int userid = _Userservice.AddUser(user);
            if (userid > 0)
            {
                var renderView = _RenderEmail.RenderToStringAsync("_EmaiAcive", user);
                bool ok = sendEmail.Send(user.email, "فعال سازی", renderView);
                return View("Welcome", user.email);
            }
            return View(model);
        }


        [Route("Account/ActiveAccount/{userid}/{Code}")]
        public IActionResult ActiveAccount(int userid, string Code)
        {
            user user = _Userservice.Finduser(userid, Code);

            if (user == null)
            {
                return NotFound();
            }
            user.isActive = true;
            user.ActiveCode = GeneratCode.GuidCode();
            _Userservice.updateuser(user);
            return RedirectToAction("Index", "Home");
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewmodel model)
        {
            user user = _Userservice.FindUserbuyeEmail(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "کاربری با این مشخصات ی افت نشد .");
                return View(model);
            }

            var renderView = _RenderEmail.RenderToStringAsync("_RecoveryPassword", user);
            sendEmail.Send(user.email, "باز یابی کلمه عبور", renderView);
            return View("recoveryMassage", user.email);
        }

        [Route("Account/Recovery/{userid}/{Code}")]
        public IActionResult Recovery(int userid, string Code)
        {
            user user = _Userservice.Finduser(userid, Code);

            ForgotPasswordViewmodel viewmodel = new ForgotPasswordViewmodel
            {
                userid = user.userid,
                Email = user.email,
            };

            if (user != null)
            {
                return View("Recovery", viewmodel);
            }
            return View();
        }


        [HttpPost]
        [Route("Account/Recovery/{userid}/{Code}")]
        public IActionResult Recovery(ForgotPasswordViewmodel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Recovery", model);
            }
            user user = _Userservice.FindUserbuyeEmail(model.Email);
            if (user != null)
            {
                user.ActiveCode = GeneratCode.GuidCode();
                user.password = model.Password.EncodePasswordMd5();
            };

            bool updateuser = _Userservice.updateuser(user);
            TempData["Result"] = updateuser ? "true" : "false";
            return View("Recovery");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewmodel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            user user = _Userservice.LoginUser(model.email, model.Password.EncodePasswordMd5());

            if (user != null)
            {
                if (user.isActive)
                {
                    var claim = new List<Claim>
                    {
                        new Claim("userid",user.userid.ToString()),
                        new Claim("useraccount",user.userAccount),
                        new Claim("useremail",user.email),
                    };
                    var option = new AuthenticationProperties
                    {
                        IsPersistent = model.Rememberme,
                    };
                    HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claim, "Coockies")), option);
                    //sendEmail.sendsms("09179105907", "ورود به حساب کاربری **وبسایت فروشگاهی کالا مارکت**");
                    return RedirectToAction("index", "Home");
                    
                }

                else
                {
                    ModelState.AddModelError("Rememberme", "حساب کاربری شما فعال نمی باشد ");
                    return View(model);
                }
            }

            ModelState.AddModelError("Rememberme", "کاربری با این مشخصات یافت نشد.");
            return View(model);
        }

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
