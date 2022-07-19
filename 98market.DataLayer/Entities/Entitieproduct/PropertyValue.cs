using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities.Entitieproduct
{
    public class PropertyValue
    {
        [Key]
        public int PropertyValueId { get; set; }


        [Display(Name = "مقدار خصوصیات")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(2, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string propertyvalue { get; set; }

        public int propertynameid { get; set; }

        public int productid { get; set; }

        #region Relation
        [ForeignKey("productid")]
        public product product { get; set; }


        [ForeignKey("propertynameid")]
        public PropertyName PropertyName { get; set; }


        #endregion
    }
}
