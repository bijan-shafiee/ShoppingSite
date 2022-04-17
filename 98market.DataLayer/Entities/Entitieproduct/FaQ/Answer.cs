using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities.Entitieproduct.FaQ
{
    public class Answer
    {
        [Key]
        public int Answerid { get; set; }

        [Display(Name = "متن پاسخ")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(10, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string AnswerDescription { get; set; }

        public DateTime CreateDate { get; set; }

        public int questionid { get; set; }

        public int userid { get; set; }

        #region relation

        [ForeignKey("questionid")]
        public question question { get; set; }


        [ForeignKey("userid")]
        public user user { get; set; }

        #endregion
    }
}
