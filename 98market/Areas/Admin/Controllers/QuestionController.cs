using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _98market.Core.Security;
using _98market.Core.Service.Interface;

namespace _98market.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckPermission(1)]
    public class QuestionController : Controller
    {
        private Iproductservice _productService;
        public QuestionController(Iproductservice productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(_productService.GetInactiveQuestions());
        }
        public IActionResult ActiveQuestion(int id)
        {
            int result = _productService.ActiveQuestion(id);
            TempData["Result"] = result > 0 ? "true" : "false";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeActiveQuestion(int id)
        {
            int result = _productService.DeActiveQuestion(id);
            TempData["Result"] = result > 0 ? "false" : "true";
            return RedirectToAction(nameof(Index));
        }

    }
}
