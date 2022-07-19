using System.ComponentModel.DataAnnotations;

namespace _98market.Core.Viewmodel
{
    public class RegisterViewmodel
    {
        [Display(Name ="ایمیل")]
        [Required(ErrorMessage ="وارد کردن {0} اجباری است .")]
        public string email { get; set; }

        [Display(Name ="ایمیل یا شماره موبایل")]
        [EmailOrPhoneNumber]
        public string PhoneOrEmail { get; set; } 

        [Display(Name = "پسورد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است .")]
        [MinLength(8, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(16, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string password { get; set; }


        [Display(Name = "تکرار پسورد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است .")]
        [Compare(nameof(password),ErrorMessage ="تکرار پسورد با خود پسورد مطابقت ندارد .")]
        public string confirmpassword { get; set; }


        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است .")]
        [MinLength(4, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(20, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string accountname { get; set; }

        [Range(typeof(bool),"true","true",ErrorMessage ="باید با قوانین سایت موافقت کنید .")]
        public bool IsAccept { get; set; }

        public string Phone { get; set; }
    }
    public class RegisteMobilerViewModel
    {
        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است .")]
        [MinLength(11, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(11, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string Mobile { get; set; }
        [Display(Name = "پسورد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است .")]
        [MinLength(8, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(16, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string Password { get; set; }

        [Display(Name = "تکرار پسورد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است .")]
        [Compare(nameof(Password), ErrorMessage = "تکرار پسورد با خود پسورد مطابقت ندارد .")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است .")]
        [MinLength(4, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(20, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        
        public string UserName { get; set; }
        public string email { get; set; }
    }

}
