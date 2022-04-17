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
    public class UserController : Controller
    {
        private IUserservice _userService;
        private IRoleService _roleService;
        public UserController(IUserservice userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        public IActionResult Index()
        {
            return View(_userService.GetUsers());
        }
        public IActionResult Roles(int id)
        {
            ViewBag.UserId = id;
            return View(_userService.GetRolesOfUser(id));
        }
        public IActionResult Addresses(int id)
        {
            return View(_userService.GetAddressesOfUser(id));
        }
        [HttpGet]
        public IActionResult Role(int id)
        {
            ViewBag.UserId = id;
            ViewBag.Roles = _roleService.GetRoles();
            return View(_userService.GetRolesOfUser(id));
        }
        [HttpPost]
        public IActionResult Role(int userId, List<int> roleIds)
        {
            int res = _userService.UpdateRolesOfUser(userId, roleIds);
            TempData["Result"] = res != 0 ? "true" : "false";
            return Redirect("/admin/user/roles/" + userId);
        }
        [HttpGet]
        public IActionResult Permission(int id)
        {
            ViewBag.UserId = id;
            ViewBag.Permissions = _roleService.GetPermissions();
            return View(_userService.GetPermissionsOfUser(id));
        }
        [HttpPost]
        public IActionResult Permission(int userId, List<int> permissionIds)
        {
            int res = _userService.UpdatePermissionsOfUser(userId, permissionIds);
            TempData["Result"] = res != 0 ? "true" : "false";
            return Redirect("/admin/user/roles/" + userId);
        }
    }
}
