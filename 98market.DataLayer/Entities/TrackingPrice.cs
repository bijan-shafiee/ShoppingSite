using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _98market.DataLayer.Entities
{
   public class TrackingPrice
    {
        [Key]
        public int TrackingPriceid { get; set; }

        [Display(Name = "عنوان هزینه ارسال پستی")]
        [Required(ErrorMessage = "وارد کردن {0}  اجباری است .")]
        public string Title { get; set; }

        [Display(Name = "مقدار هزینه ارسال پستی")]
        [Required(ErrorMessage = "وارد کردن {0}  اجباری است .")]
        public int TrackingAmount { get; set; }

        public bool IsActive { get; set; }
    }
}
