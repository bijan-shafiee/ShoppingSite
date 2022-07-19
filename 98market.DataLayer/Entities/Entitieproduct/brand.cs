using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _98market.DataLayer.Entities.Entitieproduct
{
    public class brand
    {
        [Key]
        public int brandid { get; set; }

        [Display(Name = "عنوان برند")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(2, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string brandname { get; set; }

        public string Image { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public void Active()
        {
            IsActive = true;
        }

        public void DeActive()
        {
            IsActive = false;
        }

        #region relation

        public List<product> products { get; set; }

        #endregion
    }
}
