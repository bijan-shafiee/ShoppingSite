using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _98market.Core.Security;
using _98market.Core.Service.Interface;
using _98market.DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using _98market.Core.Viewmodel;

namespace _98market.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckPermission(1)]
    public class IndexImageController : Controller
    {
        private IIndexService _IndexService;
        public IndexImageController(IIndexService IndexService)
        {
            _IndexService = IndexService;
        }
        public IActionResult Index()
        {
            return View(_IndexService.GetIndexImage());
        }
        [HttpGet]
        public IActionResult UpdateIndexImage()
        {
            return View(_IndexService.GetIndexImageViewModel());
        }
        [HttpPost]
        public IActionResult UpdateIndexImage(IndexImageViewModel indexImage)
        {
            int indexImageId = _IndexService.UpdateIndexImage(indexImage);
            TempData["Result"] = indexImageId > 0 ? "true" : "false";
            return RedirectToAction(nameof(Index));
        }
    }
}
