using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _98market.Core.Viewmodel
{
    public class RegisterViewmodel
    {
        [Display(Name ="ایمیل")]
        [Required(ErrorMessage ="وارد کردن {0} اجباری است .")]
        public string email { get; set; }



        [Display(Name = "پسورد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است .")]
        public string password { get; set; }


        [Display(Name = "تکرار پسورد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است .")]
        [Compare(nameof(password),ErrorMessage ="تکرار پسورد با خود پسورد متابقت ندارد .")]
        public string confirmpassword { get; set; }


        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است .")]
        public string accountname { get; set; }

        [Range(typeof(bool),"true","true",ErrorMessage ="باید با قوانین سایت موافقت کنید .")]
        public bool IsAccept { get; set; }
    }
}
