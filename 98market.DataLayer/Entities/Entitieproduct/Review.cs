using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities.Entitieproduct
{
    public class Review
    {
        [Key]
        public int reviewid { get; set; }

        [Display(Name = "توضیحات محصول")]
        [MaxLength(10000, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string reviewDescription { get; set; }

        [Display(Name = "نقات ضعف")]
        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string Reviewnegative { get; set; }

        [Display(Name = "نقات قوت")]
        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string ReviewPositive { get; set; }

        [Display(Name = "عنوان مقاله")]
        [MaxLength(10000, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string AticleTitle { get; set; }

        [Display(Name = "توضیحات مقاله")]
        public string ArticleDescription { get; set; }

        public int productid { get; set; }


        #region Relation
        [ForeignKey("productid")]
        public product product { get; set; }


        #endregion
    }
}
