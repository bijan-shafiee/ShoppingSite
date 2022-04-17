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
    public class guranteeController : Controller
    {
        private IguranteeService _guranteeservice;
        public guranteeController(IguranteeService guranteeservice)
        {
            _guranteeservice = guranteeservice;
        }
        public IActionResult Showallgurantee()
        {
            return View(_guranteeservice.ShowAllGurantee());
        }

        [HttpGet]
        public IActionResult AddGurantee()
        {
            return PartialView("_AddGurantee");
        }

        [HttpPost]
        public IActionResult AddGurantee(ProductGurantee productGurantee)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Showallgurantee));
            }
            if (_guranteeservice.ExistGurantee(productGurantee.guranteename,0))
            {
                return Json(5);
            }
            int guranteid = _guranteeservice.AddGurante(productGurantee);
            int sendjson = guranteid > 0 ? 1 : 4;
            return Json(sendjson);
        }

        [HttpGet]
        public IActionResult updateGurantee(int id)
        {

            return PartialView("_Updategurantee",_guranteeservice.FindGuranteebuyeid(id));
        }

        [HttpPost]
        public IActionResult updateGurantee(ProductGurantee productGurantee)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Showallgurantee));
            }
            if (_guranteeservice.ExistGurantee(productGurantee.guranteename, productGurantee.GuranteeId))
            {
            
                return RedirectToAction(nameof(Showallgurantee));
            }
            bool guranteid = _guranteeservice.updategurantee(productGurantee);
            int sendjson = guranteid ? 2 : 4;
            return Json(sendjson);
        }
        [HttpGet]
        public IActionResult DeleteGurantee(int id)
        {

            return PartialView("_DeleteGurantee", _guranteeservice.FindGuranteebuyeid(id));
        }

        [HttpPost]
        public IActionResult DeleteGurantee(ProductGurantee productGurantee)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Showallgurantee));
            }

            bool guranteid = _guranteeservice.DeleteGurantee(productGurantee);
            int sendjson = guranteid ? 3 : 4;
            return Json(sendjson);
        }

    }
}
