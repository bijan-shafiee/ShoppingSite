using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _98market.Core.Viewmodel
{
    public class ForgotPasswordViewmodel
    {
        public int userid { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [Compare(nameof(Password), ErrorMessage = "تکرار با کلمه عبور متابقت ندارد .")]
        [DataType(DataType.Password)]
        public string Confirmpassword { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        public string Email { get; set; }
    }
}
