using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _98market.Core.Security;
using _98market.Core.Service.Interface;
using _98market.DataLayer.Entities.Entitieproduct;
using Microsoft.AspNetCore.Http;
using _98market.Core.ExtentionMethod;

namespace _98market.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckPermission(1)]
    public class BrandController : Controller
    {
        private IBrandService _BrandService;
        public BrandController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }
        public IActionResult ShowAllBrand()
        {
            return View(_BrandService.ShowAllBrandforadmin());
        }

        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBrand(brand Brand, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(Brand);
            }
            if (file == null)
            {
                ModelState.AddModelError("Image", "لطفا یک تصویر انتخاب نمایید .");
                return View(Brand);

            }

            string imgname = UploadImgbrand.CreateImage(file);
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllBrand));
            }

            Brand.Image = imgname;
            Brand.CreateDate = DateTime.Now;
            int Brandid = _BrandService.AddBrand(Brand);
            TempData["Result"] = Brandid > 0 ? "true" : "false";
            return RedirectToAction(nameof(ShowAllBrand));

        }
        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            return View(_BrandService.GetBrand(id));
        }
        [HttpPost]
        public IActionResult UpdateBrand(brand brand, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }
            if (file != null)
            {
                UploadImgbrand.DeleteImg("ImageSite", brand.Image);
                string imgname = UploadImgbrand.CreateImage(file);
                if (imgname == "false")
                {
                    TempData["Result"] = "false";
                    return RedirectToAction(nameof(ShowAllBrand));
                }

                brand.Image = imgname;
            }
            int Brandid = _BrandService.UpdateBrand(brand);
            TempData["Result"] = Brandid > 0 ? "true" : "false";
            return RedirectToAction(nameof(ShowAllBrand));
        }
        public IActionResult ActiveBrand(int id)
        {
            _BrandService.ActiveBrand(id);
            return RedirectToAction("showAllBrand");//action index
        }
        public IActionResult DeActiveBrand(int id)
        {
            _BrandService.DeActiveBrand(id);
            return RedirectToAction("showAllBrand");//action index
        }
    }
}
