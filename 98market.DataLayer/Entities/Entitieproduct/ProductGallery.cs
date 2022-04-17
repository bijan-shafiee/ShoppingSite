using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities.Entitieproduct
{
        public class ProductGallery
        {
        [Key]
        public int galleryid { get; set; }
        [Display(Name = "تصویر محصول")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        public string imagename { get; set; }

        public int productid { get; set; }


        #region Relation

        [ForeignKey("productid")]
        public product product { get; set; }

        #endregion
    }
}
