using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _98market.Core.Viewmodel
{
    public class showPriceForProductViewmodel
    {
        public int Productpriceid { get; set; }


        [Display(Name = "قیمت اصلی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        public int mainprice { get; set; }


        [Display(Name = "قیمت ویژه")]
        public int? sepcialprice { get; set; }


        [Display(Name = "تعداد کالا")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        public int count { get; set; }



        [Display(Name = "تعداد خرید کاربر")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        public int MaxorderCount { get; set; }


        public string Colorname { get; set; }

        public string guranteename { get; set; }

        public int productid { get; set; }


        [Display(Name = "تاریخ ایجاد")]
        public DateTime Createdate { get; set; }

        [Display(Name = "تاریخ پایان تخفیف")]
        public DateTime? EndDateDisCount { get; set; }
        public bool IsActive { get; set; }


        public void Active()
        {
            IsActive = true;
        }

        public void DeActive()
        {
            IsActive = false;
        }
    }
}
