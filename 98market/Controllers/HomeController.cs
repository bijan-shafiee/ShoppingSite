using _98market.Core.Service.Interface;
using _98market.DataLayer.Entities.Entitieproduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace _98market.Controllers
{
    public class HomeController : Controller
    {
        private Iproductservice _Productservice;
        private IBrandService _BrandService;
        private IIndexService _IndexService;
        private ICategoryService _CategoryService;
        public HomeController(Iproductservice Productservice, IBrandService BrandService, IIndexService IndexService, ICategoryService CategoryService)
        {
            _Productservice = Productservice;
            _BrandService = BrandService;
            _IndexService = IndexService;
            _CategoryService = CategoryService;
        }

     //   [CheckPermission(1)]
        public IActionResult Index()
        {
          //  sendEmail.sendsms("09179105907","تست سرویس ");
            ViewBag.sepcialprice = _Productservice.ShowAllSepcialproduct();
            ViewBag.RandomProduct = _Productservice.RandomProduct();
            ViewBag.Brands = _BrandService.ShowAllBrand();
            ViewBag.IndexImage = _IndexService.GetIndexImage();
            ViewBag.SliderCategories = _CategoryService.GetSliderCategories();
            return View();
        }

        public IActionResult Error()
        {

            return View();
        }
        public IActionResult AboutUs()
        {

            return View();
        }
    }
}
