using _98market.Core.Security;
using _98market.Core.Service.Interface;
using _98market.DataLayer.Entities.Entitieproduct;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _98market.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckPermission(1)]
    public class CategoryController : Controller
    {
        private ICategoryService _Categoryservice;
        public CategoryController(ICategoryService Categoryservice)
        {
            _Categoryservice = Categoryservice;
        }
        public IActionResult showAllCategory()
        {
            return View(_Categoryservice.ShowAllCategory());
        }

        [HttpGet]
        public IActionResult AddCategory(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.id = category.SubCategory;
                return View(category);
            }
            if (_Categoryservice.ExistCategory(category.CategoryFaTitle, category.CategoryEnTitle, 0))
            {
                ModelState.AddModelError("CategoryEnTitle", "دسته بندی تکراری است .");
                ViewBag.id = category.SubCategory;
                return View(category);
            }
            int cateid = _Categoryservice.AddCategory(category);
            TempData["Result"] = cateid > 0 ? "true" : "false";

            return RedirectToAction(nameof(showAllCategory));
        }

        [HttpGet]
        public IActionResult ShowAllSubCategory(int id)
        {
            ViewBag.id = id;
            return View(_Categoryservice.showAllSubCategory(id));
        }

        [HttpGet]
        public IActionResult ShowAllSubCategorythree(int id)
        {
            ViewBag.id = id;
            return View(_Categoryservice.showAllSubCategory(id));
        }

    }
}
