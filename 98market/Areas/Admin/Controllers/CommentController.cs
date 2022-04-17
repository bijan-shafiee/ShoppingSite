using _98market.Core.Security;
using _98market.Core.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _98market.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckPermission(1)]
    public class CommentController : Controller
    {
        private Iproductservice _productService;
        public CommentController(Iproductservice productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(_productService.GetInactiveComments());
        }
        public IActionResult ActiveComment(int id)
        {
            int result = _productService.ActiveComment(id);
            TempData["Result"] = result > 0 ? "true" : "false";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeActiveComment(int id)
        {
            int result = _productService.DeActiveComment(id);
            TempData["Result"] = result > 0 ? "false" : "true";
            return RedirectToAction(nameof(Index));
        }
    }
}
