using _98market.Core.Service.Interface;
using _98market.Core.Viewmodel;
using _98market.DataLayer.Entities.Address;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _98market.Areas.User.Controllers
{
    [Area("User")]
    public class ProfileUserController : Controller
    {
        private IAddressService _AddressService;
        private IUserservice _usersevice;
        public ProfileUserController(IAddressService AddressService
            , IUserservice usersevice)
        {
            _usersevice = usersevice;
            _AddressService = AddressService;
        }
        [Authorize]
        public IActionResult Index()
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            return View(_usersevice.informationAccount(userid));
        }

        [Authorize]
        public IActionResult Address()
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            ViewBag.information = _usersevice.informationAccount(userid);
            return View(_AddressService.findaddressforuser(userid));
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddAddres()
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            ViewBag.province = _AddressService.showallProvince();
            ViewBag.information = _usersevice.informationAccount(userid);
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddAddres(useraddress model)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            model.userid = userid;
            if (!ModelState.IsValid)
            {
                ViewBag.province = _AddressService.showallProvince();
                ViewBag.information = _usersevice.informationAccount(userid);
                return View(model);
            }
            ViewBag.information = _usersevice.informationAccount(userid);
            int addresid = _AddressService.addusraddress(model);
            TempData["Result"] = addresid > 0 ? "true" : "false";
            return RedirectToAction(nameof(Address));

        }


        [HttpPost]
        [Route("City")]
        public IActionResult City(int id)
        {
            var city = _AddressService.showallcityForProvince(id);
            return Json(city);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Updateaddress()
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            ShowAddressForUserViewmodel useraddress = _AddressService.findaddressforuser(userid);
            ViewBag.province = _AddressService.showallProvince();
            ViewBag.City = _AddressService.showallcityForProvince(useraddress.provinceid);
            ViewBag.information = _usersevice.informationAccount(userid);
            return View(useraddress);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Updateaddress(ShowAddressForUserViewmodel viewmodel)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            if (!ModelState.IsValid)
            {
                ViewBag.province = _AddressService.showallProvince();
                ViewBag.City = _AddressService.showallcityForProvince(viewmodel.provinceid);
                ViewBag.information = _usersevice.informationAccount(userid);
                return View(viewmodel);
            }
            useraddress useraddress = new useraddress
            {
                addresid = viewmodel.addresid,
                cityid = viewmodel.cityid,
                FullAddress = viewmodel.FullAddress,
                Isdelete = false,
                Landlinephonenumber = viewmodel.Landlinephonenumber,
                phone = viewmodel.phone,
                Plaque = viewmodel.Plaque,
                postalCode = (int)viewmodel.postalCode,
                provinceid = viewmodel.provinceid,
                Recipientname = viewmodel.Recipientname,
                unit = viewmodel.unit,
                userid = userid
            };

            bool updateaddres = _AddressService.updateaddress(useraddress);
            TempData["Result"] = updateaddres ? "true" : "false";
            return RedirectToAction(nameof(Address));

        }

        [HttpGet]
        [Authorize]
        [Route("EditUser")]
        public IActionResult EditUser()
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            ViewBag.information = _usersevice.informationAccount(userid);
            return View(_usersevice.finduserbuyeid(userid));
        }

        [HttpPost]
        [Authorize]
        [Route("EditUser")]
        public IActionResult EditUser(edituserViewmodel edituser)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            var model = _usersevice.findEditUserbuyeid(userid);

            model.userfamily = edituser.userfamily;
            model.username = edituser.username;
            model.email = edituser.email;
            model.phone = edituser.phone;

            _usersevice.updateuser(model);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        [Authorize]
        [Route("favoirate")]
        public IActionResult favoirate()
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            ViewBag.information = _usersevice.informationAccount(userid);
            return View(_usersevice.showfavoirateUser(userid));
        }



        [Route("showorder")]
        [Authorize]
        public IActionResult showorder()
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            ViewBag.information = _usersevice.informationAccount(userid);
            return View(_usersevice.showorderForUsers(userid));

        }


        [Route("mycomment")]
        [Authorize]
        public IActionResult mycomment()
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            ViewBag.information = _usersevice.informationAccount(userid);
            return View(_usersevice.mycomment(userid));
        }

        [Route("showDetailorders/{id}")]
        [Authorize]
        public IActionResult showDetailorders(int id)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            ViewBag.information = _usersevice.informationAccount(userid);
            return View(_usersevice.showDetailorders(id));
        }
    }
}
