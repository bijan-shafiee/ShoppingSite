using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _98market.DataLayer.Entities
{
    public class MainSlider
    {
        [Key]
        public int Sliderid { get; set; }
        [Display(Name ="عنوان اسلایدر")]
        [Required(ErrorMessage = "وارد کردن {0}  اجباری است .")]
        public string SliderTitle { get; set; }
        [Display(Name = "آلت اسلایدر")]
        public string SliderAlt { get; set; }
        [Display(Name = "ترتیب اسلایدر")]
        [Required(ErrorMessage = "وارد کردن {0}  اجباری است .")]
        public int SliderSort { get; set; }
        [Display(Name = "لینک اسلایدر")]
        public string SliderLink { get; set; }
        [Display(Name = "تصویر اسلایدر")]
        public string SliderImg { get; set; }
        public bool IsActive { get; set; }

    }
}
