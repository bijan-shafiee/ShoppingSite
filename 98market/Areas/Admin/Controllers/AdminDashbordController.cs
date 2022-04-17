using _98market.Core.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _98market.Core.Security;

namespace _98market.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckPermission(1)]
    public class AdminDashbordController : Controller
    {
        private ICartService _CartService;
        public AdminDashbordController(ICartService CartService)
        {
            _CartService = CartService;
        }
        [Route("Admin")]
        public IActionResult Index()
        {
            ViewBag.chart = _CartService.hichart();
            return View();
        }
    }
}
