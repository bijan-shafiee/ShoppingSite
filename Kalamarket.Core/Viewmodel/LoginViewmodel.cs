using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _98market.Core.Viewmodel
{
    public class LoginViewmodel
    {
        [Required(ErrorMessage ="وارد کردن ایمیل اجباری است")]
        public string email { get; set; }

        [Required(ErrorMessage = "وارد کردن پسورد اجباری است")]
        public string Password { get; set; }

        public bool Rememberme { get; set; }
    }

    public class LoginMobileViewModel
    {
        [Required(ErrorMessage = "لطفا موبایل را وارد کنید")]
        public string Mobile { get; set; }
       
    }

}
