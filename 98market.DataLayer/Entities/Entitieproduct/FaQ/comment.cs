using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities.Entitieproduct.FaQ
{
    public class comment
    {
        [Key]
        public int commentid { get; set; }
        [Display(Name = "عنوان نظر")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(4, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string commentTitle { get; set; }


        [Display(Name = "توضیحیات نظر")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(10, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(500, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string commnetDescription { get; set; }

        public int Star { get; set; }

        public int Quality { get; set; }

        public int BuyWorth { get; set; }

        public int Innovation { get; set; }

        public int Abilities { get; set; }

        public int EaseOfUse { get; set; }

        public int Appearance { get; set; }


        public int commentlike { get; set; }


        public int commentDislike { get; set; }


        public DateTime CreateDate { get; set; }

        public bool IsActive { get; set; }

        public byte recommend { get; set; }

        public int productid { get; set; }

        public int userid { get; set; }

        #region relation

        [ForeignKey("productid")]
        public product product { get; set; }

        [ForeignKey("userid")]
        public user user { get; set; }

        #endregion
    }
}
