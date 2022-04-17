using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _98market.DataLayer.Entities.Entitieproduct
{
    
    public class ProductGurantee
    {
        [Key]
        public int GuranteeId { get; set; }

        [Display(Name = "اسم گارانتی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(2, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(150, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string guranteename { get; set; }

        public bool IsDelete { get; set; }


        #region relation
        public List<ProductPrice> productPrices { get; set; }
        #endregion
    }
}
