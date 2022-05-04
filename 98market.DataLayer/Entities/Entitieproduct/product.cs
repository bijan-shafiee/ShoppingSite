using _98market.DataLayer.Entities.Entitieproduct.FaQ;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities.Entitieproduct
{
    public class product
    {
        [Key]
        public int productid { get; set; }

        [Display(Name = "عنوان فارسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید .")]
        [MinLength(2, ErrorMessage = "{0} نمیتواند کمنتر از {1} باشد .")]
        [MaxLength(500, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد .")]
        public string productFaTitle { get; set; }

        [Display(Name = "عنوان اینگلیسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید .")]
        [MinLength(2, ErrorMessage = "{0} نمیتواند کمنتر از {1} باشد .")]
        [MaxLength(500, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد .")]
        public string productEnTitle { get; set; }

        [Display(Name = "تعداد فروش")]
        public int ProductSell { get; set; }

        [Display(Name = "امتیاز محصول")]
        public byte producStart { get; set; }

        [Display(Name = "تصویر محصول")]
        public string Productimage { get; set; }

        [Display(Name = "برچسب های محصول")]
        public string productTag { get; set; }

        public DateTime ProductCreate { get; set; }

        public DateTime ProductUpdate { get; set; }

        [Display(Name = "وزن محصول")]
        public int productweith { get; set; }

        [Display(Name = "تایید شود ؟!")]
        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public bool IsOrginal { get; set; }


        public int Categoryid { get; set; }
        public int brandid { get; set; }


        [NotMapped]
        public int mainprice { get; set; }

        [NotMapped]
        public int? sepcialprice { get; set; }

        #region Relation
        [ForeignKey("Categoryid")]
        public Category Category { get; set; }

        [ForeignKey("brandid")]
        public brand brand { get; set; }

        public List<Review> reviews { get; set; }

        public List<question> questions { get; set; }

        public List<comment> comments { get; set; }
        public List<ProductGallery> ProductGallerys { get; set; }
        public List<ProductPrice> productPrices { get; set; }
        public List<Faviorate> Faviorates { get; set; }
        public List<ProductReating> ProductReatings { get; set; }
        public List<PropertyValue> PropertyValues { get; set; }
        public List<ProductView> ProductViews { get; set; }
        public List<Rate> Rates { get; set; }
        #endregion
    }
}
