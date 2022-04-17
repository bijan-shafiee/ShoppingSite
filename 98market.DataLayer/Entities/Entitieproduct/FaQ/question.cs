using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities.Entitieproduct.FaQ
{
    public class question
    {
        [Key]
        public int questionid { get; set; }

        [Display(Name = "متن سوال")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(10, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string questionDescription { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsActive { get; set; }

        public int userid { get; set; }

        public int productid { get; set; }

        #region Relation

        [ForeignKey("userid")]
        public user user { get; set; }

        [ForeignKey("productid")]
        public product product { get; set; }


        public List<Answer> answers { get; set; }
        #endregion
    }
}
