using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _98market.Core.Viewmodel
{
    public class UpdatePropertynameViewmodel
    {

        public int PropertyNameId { get; set; }

        [Display(Name = "عنوان خصوصیات")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(5, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string PropertyTitle { get; set; }

        public int pcId { get; set; }

   
        public int Categoryid { get; set; }

    }
}
