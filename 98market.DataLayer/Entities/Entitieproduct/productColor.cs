using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _98market.DataLayer.Entities.Entitieproduct
{
        public class productColor
        {
        [Key]
        public int colorid { get; set; }

        [Display(Name = "اسم رنگ")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(2, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string colorname { get; set; }


        [Display(Name = "کد رنگ")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MaxLength(20, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string ColorCode { get; set; }

        #region relation
        public List<ProductPrice> productPrices { get; set; }
        #endregion
    }
}
