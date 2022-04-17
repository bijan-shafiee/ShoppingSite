using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace _98market.Core.Viewmodel
{
    public class IndexImageViewModel
    {
        [Display(Name = "کنار اسلایدر")]
        public IFormFile Image1 { get; set; }
        [Display(Name = "کنار اسلایدر")]
        public IFormFile Image2 { get; set; }
        [Display(Name = "زیر اسلایدر")]
        public IFormFile Image3 { get; set; }
        [Display(Name = "تمام عرض وسط صفحه")]
        public IFormFile Image4 { get; set; }
        [Display(Name = "عکس کوچک")]
        public IFormFile Image5 { get; set; }
        [Display(Name = "عکس کوچک")]
        public IFormFile Image6 { get; set; }
        [Display(Name = "عکس کوچک")]
        public IFormFile Image7 { get; set; }
        [Display(Name = "عکس کوچک")]
        public IFormFile Image8 { get; set; }
        [Display(Name = "عکس کوچک")]
        public IFormFile Image9 { get; set; }
        [Display(Name = "عکس کوچک")]
        public IFormFile Image10 { get; set; }
        [Display(Name = "عکس کوچک")]
        public IFormFile Image11 { get; set; }
        [Display(Name = "عکس کوچک")]
        public IFormFile Image12 { get; set; }

        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public string Link3 { get; set; }
        public string Link4 { get; set; }
        public string Link5 { get; set; }
        public string Link6 { get; set; }
        public string Link7 { get; set; }
        public string Link8 { get; set; }
        public string Link9 { get; set; }
        public string Link10 { get; set; }
        public string Link11 { get; set; }
        public string Link12 { get; set; }
    }
}
