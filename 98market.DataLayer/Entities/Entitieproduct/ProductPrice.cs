using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities.Entitieproduct
{
    public class ProductPrice
    {
        [Key]
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


        public int productcolorid { get; set; }
        public int productguranteeid { get; set; }
        public int productid { get; set; }

        public DateTime Createdate { get; set; }
        public DateTime? EndDateDisCount { get; set; }

        #region relation
        [ForeignKey("productcolorid")]
        public productColor productColor { get; set; }


        [ForeignKey("productguranteeid")]
        public ProductGurantee ProductGurantee { get; set; }

        [ForeignKey("productid")]
        public product product { get; set; }

        #endregion
    }
}
