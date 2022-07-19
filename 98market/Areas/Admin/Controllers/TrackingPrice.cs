using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _98market.Core.Security;
using _98market.Core.Service.Interface;
using Microsoft.AspNetCore.Http;
using _98market.Core.ExtentionMethod;
using _98market.DataLayer.Entities;

namespace _98market.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckPermission(1)]
    public class TrackingPriceController : Controller
    {
        private ITrackingPriceService _TrackingPriceService;
        public TrackingPriceController(ITrackingPriceService TrackingPriceService)
        {
            _TrackingPriceService = TrackingPriceService;
        }
        public IActionResult ShowAllTrackingPrice()
        {
            return View(_TrackingPriceService.ShowAllTrackingPrice());
        }

        [HttpGet]
        public IActionResult AddTrackingPrice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTrackingPrice(TrackingPrice TrackingPrice, IFormFile file)
        {
            return null;

        }
        [HttpGet]
        public IActionResult UpdateTrackingPrice(int id)
        {
            return null;
        }
        [HttpPost]
        public IActionResult UpdateTrackingPrice(TrackingPrice TrackingPrice, IFormFile file)
        {
           
            return null;
        }
        public IActionResult ActiveTrackingPrice(int id)
        {
            return null;
        }
        public IActionResult DeActiveTrackingPrice(int id)
        {
            return null;
        }
    
}
}
