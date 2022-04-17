using _98market.Core.Security;
using _98market.Core.Service.Interface;
using _98market.DataLayer.Entities.Role;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _98market.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckPermission(1)]
    public class RoleController : Controller
    {
        private IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public IActionResult Index()
        {
            return View(_roleService.GetRolesAndPermissions());
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(role role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }

            int roleId = _roleService.AddRole(role);
            TempData["Result"] = roleId > 0 ? "true" : "false";

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            return View(_roleService.GetRole(id));
        }
        [HttpPost]
        public IActionResult UpdateRole(role role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }

            int roleId = _roleService.UpdateRole(role);
            TempData["Result"] = roleId > 0 ? "true" : "false";

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Permissions()
        {
            return View(_roleService.GetPermissions());
        }
        [HttpGet]
        public IActionResult AddPermission()
        {
            ViewBag.Roles = _roleService.GetRoles();
            return View();
        }

        [HttpPost]
        public IActionResult AddPermission(permission permission, List<int> roleIds)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = _roleService.GetRoles();
                return View(permission);
            }

            int permissionId = _roleService.AddPermission(permission, roleIds);
            TempData["Result"] = permissionId > 0 ? "true" : "false";

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult UpdatePermission(int id)
        {
            ViewBag.Roles = _roleService.GetRoles();
            ViewBag.RolesOfPermission = _roleService.GetRolesOfPermission(id);
            return View(_roleService.GetPermission(id));
        }
        [HttpPost]
        public IActionResult UpdatePermission(permission permission, List<int> roleIds)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = _roleService.GetRoles();
                ViewBag.RolesOfPermission = _roleService.GetRolesOfPermission(permission.permissionid);
                return View(permission);
            }

            int permissionId = _roleService.UpdatePermission(permission, roleIds);
            TempData["Result"] = permissionId > 0 ? "true" : "false";

            return RedirectToAction(nameof(Index));
        }
    }
}
