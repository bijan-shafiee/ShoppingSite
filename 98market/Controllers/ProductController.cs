using _98market.Core.ExtentionMethod;
using _98market.Core.Service;
using _98market.Core.Service.Interface;
using _98market.Core.Viewmodel;
using _98market.DataLayer.Entities;
using _98market.DataLayer.Entities.Address;
using _98market.DataLayer.Entities.Entitieproduct;
using _98market.DataLayer.Entities.Entitieproduct.FaQ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using _98market.Core.ZarinPal;

namespace _98market.Controllers
{
    public class ProductController : Controller
    {
        private Iproductservice _productservice;
        private IBrandService _Brandservice;
        private ICategoryService _Categoryservice;
        private ICartService _CartService;
        private IDiscountService _Discountservice;
        private IAddressService _addressService;
        private readonly IZarinPalFactory _zarinPalFactory;
        public ProductController(Iproductservice productservice, IBrandService Brandservice, IAddressService addressService,
            ICategoryService Categoryservice, ICartService CartService, IDiscountService Discountservice, IZarinPalFactory zarinPalFactory)
        {
            _productservice = productservice;
            _Brandservice = Brandservice;
            _Categoryservice = Categoryservice;
            _CartService = CartService;
            _Discountservice = Discountservice;
            _zarinPalFactory = zarinPalFactory;
            _addressService = addressService;
        }


        public IActionResult Detail(int id)
        {
            ///var b = _productservice.ShowDetailsProduct(id);
            var detailproduct = _productservice.DetailProduct(id);
            var productprice = _productservice.GetProductprice(id);

            ViewBag.PropertyValue = _productservice.showValueForProduct(id);
            ViewBag.Galley = _productservice.showgalleryforproduct(id);
            ViewBag.HasUserRated = false;
            if (User.Identity.IsAuthenticated)
            {
                // views
                int userid = int.Parse(User.FindFirst("userid").Value);
                if (!_productservice.HasUserViewedProduct(userid, id))
                    _productservice.AddProductView(userid, id);
                // favourites                
                ViewBag.IsFavourite = _productservice.findfavioratebuyeuserid(userid, id) != null;
                // rate
                ViewBag.HasUserRated = _productservice.HasUserRated(userid, id);
            }
            if (detailproduct == null)
            {
                return NotFound();
            }

            #region Show Rates
            ViewBag.Average = _productservice.GetAverageOfRates(id);
            ViewBag.ProductId = id;
            #endregion
            return View(Tuple.Create(detailproduct, productprice));
        }

        public IActionResult ShowReview(int id)
        {
            return View(_productservice.findreviewbuyeid(id));
        }

        public IActionResult ShowAllProperty(int id)
        {
            return View(_productservice.ShowAllPropertyForProduct(id));
        }

        public IActionResult ShowComment(int id)
        {
            ViewBag.ProductId = id;
            ViewBag.Reating = _productservice.GetreatingForProduct(id);
            ViewBag.Scales = _productservice.GetAverageOfCommentScales(id);
            ViewBag.ProductName = _productservice.findproductbuyeid(id).productFaTitle;
            return View(_productservice.ShowAllCommentForProduct(id));
        }


        public IActionResult ShowFaq(int id)
        {
            TempData["productid"] = id;
            return View(_productservice.ShowAllFaq(id));
        }


        [Route("compare/{id?}/{id2?}/{id3?}")]
        public IActionResult Compare(int id, int? id2, int? id3)
        {
            List<int?> Listid = new List<int?> { id, id2, id3 };

            if (id <= 0)
            {
                return RedirectToAction("Index", "Home");
            }
            var ListProduct = _productservice.Showcompareproduct(Listid);

            var productgroup = ListProduct.GroupBy(p => p.productid).Select(p => new comapreviewmodel
            {
                categoryid = p.FirstOrDefault().categoryid,
                productfatitle = p.FirstOrDefault().productfatitle,
                productid = p.Key,
                productimg = p.FirstOrDefault().productimg,
                productprice = p.FirstOrDefault().productprice,
                Compareviewmodel = p.FirstOrDefault().Compareviewmodel,

            }).ToList();

            ViewBag.property = _productservice.ShowPropertyCompare(productgroup[0].categoryid);
            ViewBag.Product = _productservice.GetProductForCompare(productgroup[0].categoryid, Listid);
            return View(productgroup.OrderBy(p => p.productid));

        }

        [HttpPost]
        [Route("changefaviorate")]
        public IActionResult changefaviorate(int productid)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            Faviorate faviorate = _productservice.findfavioratebuyeuserid(userid, productid);
            Faviorate addorDelete = new Faviorate();
            if (faviorate == null)
            {
                addorDelete.productid = productid;
                addorDelete.userid = userid;

                bool result = _productservice.AddFaiorate(addorDelete);
                return Json(result);
            }
            else
            {
                bool result = _productservice.removefaviorate(faviorate);
                return Json(result); ;
            }
        }

        [HttpPost]
        [Route("CheckFaviorate")]
        public IActionResult CheckFaviorate(int productid)
        {
            if (User.Identity.IsAuthenticated)
            {
                int userid = int.Parse(User.FindFirst("userid").Value);
                Faviorate faviorate = _productservice.findfavioratebuyeuserid(userid, productid);
                if (faviorate != null)
                {
                    return Json(true);
                }
                return Json(false);
            }
            return Json(false);

        }

        [HttpPost]
        [Route("AddOrDeleteFaviorate")]
        public IActionResult AddOrDeleteFaviorate(int productid)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            Faviorate faviorate = _productservice.findfavioratebuyeuserid(userid, productid);
            Faviorate Addfaviorate = new Faviorate();
            if (faviorate != null)
            {
                _productservice.removefaviorate(faviorate);
                return Json(true);
            }
            else
            {
                Addfaviorate.productid = productid;
                Addfaviorate.userid = userid;
                _productservice.AddFaiorate(Addfaviorate);
                return Json(false);
            }
        }
        public IActionResult RemoveFavourite(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                int userid = int.Parse(User.FindFirst("userid").Value);
                Faviorate favourite = _productservice.findfavioratebuyeuserid(userid, id);
                _productservice.removefaviorate(favourite);
            }
            return Redirect("/Product/Detail/" + id);
        }
        public IActionResult AddFavourite(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                int userid = int.Parse(User.FindFirst("userid").Value);
                Faviorate favourite = new Faviorate()
                {
                    userid = userid,
                    productid = id
                };
                _productservice.AddFaiorate(favourite);
            }
            return Redirect("/Product/Detail/" + id);
        }
        [HttpPost]
        public IActionResult AddQustionOrAnswer(string text, int questionid, int productid,string returnUrl="")
        {
            int userid = int.Parse(User.FindFirst("userid").Value);

            if (questionid > 0)
            {
                Answer answer = new Answer
                {
                    AnswerDescription = text,
                    CreateDate = DateTime.Now,
                    questionid = questionid,
                    userid = userid,

                };
                int answerid = _productservice.AddAnswer(answer);

                if (!string.IsNullOrWhiteSpace(returnUrl))
                    return Redirect(returnUrl);

                return Json(answerid);
            }
            else
            {
                question question = new question
                {
                    userid = userid,
                    questionDescription = text,
                    CreateDate = DateTime.Now,
                    IsActive = false,
                    productid = productid,
                };
                int Qustionid = _productservice.AddQustion(question);

                if (!string.IsNullOrWhiteSpace(returnUrl))
                    return Redirect(returnUrl);

                return Json(Qustionid);
            }

        }

        [HttpGet]
        public IActionResult search(List<int> categoryid, List<int> propertyValues,
            List<int> brandid, string text = "", string minprice = "", string maxprice = "", int sort = 1)
        {
            if (text == null)
            {
                text = "";
            }
            var ListProduct = _productservice.search(text, categoryid, propertyValues, brandid, minprice.replacePrice(), maxprice.replacePrice(), sort);
            ViewBag.brand = _Brandservice.ShowAllBrand();
            ViewBag.category = _Categoryservice.Showsubcategory();

            ViewBag.text = text;
            ViewBag.sort = sort;
            ViewBag.categoryid = categoryid;
            ViewBag.brandid = brandid;
            ViewBag.PropertyValues = propertyValues;
            List<PropertyName> propertyNames = new List<PropertyName>();
            ViewBag.PropertyNames = propertyNames;
            try
            {
                foreach (int categoryId in categoryid)
                {
                    propertyNames.AddRange(_productservice.GetPropertyNamesOfCategory(categoryId));
                }
            }
            catch
            {
                
            }
            return View(ListProduct);
        }

        [Route("ShowAllProductForBasket")]
        public IActionResult ShowAllProductForBasket()
        {
            List<ShowBasketViewmodel> showBaskets = new List<ShowBasketViewmodel>();

            if (!User.Identity.IsAuthenticated)
                return View(showBaskets);

            int userid = int.Parse(User.FindFirst("userid").Value);
            showBaskets = _CartService.ShowAllProductForBasket(userid);

            return View(showBaskets);

        }
        [Route("Checkout")]
        [HttpGet]
        public IActionResult Checkout()
        {
            int userId = int.Parse(User.FindFirst("userid").Value);
            ViewBag.Provinces = _addressService.showallProvince();
            ViewBag.Address = _addressService.findaddressforuser(userId);
            ViewBag.ChooseAddress = 0;
            if (ViewBag.Address == null)
                ViewBag.ChooseAddress = 1;
            ViewBag.NewPlaque = 0;
            ViewBag.NewPostalCode = 0;
            ViewBag.NewUnit = 0;
            ViewBag.Province = 0;
            ViewBag.City = 0;
            return View(_CartService.DetailCart(userId));
        }
        [Route("Checkout")]
        [HttpPost]
        public IActionResult Checkout(int chooseAddress, int addressId, string recepientName, string phone,
            string postalCode, string fullAddress, string newRecepientName, string newPhone, string newLandLinePhone,
            int newProvince, int newPlaque, int newCity, int newUnit, string newPostalCode, string newFullAddress
            , string cartDescription)
        {
            int userId = int.Parse(User.FindFirst("userid").Value);
            ViewBag.Provinces = _addressService.showallProvince();
            ShowAddressForUserViewmodel userAddress = new ShowAddressForUserViewmodel()
            {
                addresid = addressId,
                FullAddress = fullAddress,
                phone = phone,
                postalCode = postalCode,
                Recipientname = recepientName
            };
            ViewBag.ChooseAddress = chooseAddress;
            ViewBag.Address = userAddress;
            ViewBag.NewPlaque = newPlaque;
            ViewBag.NewPostalCode = newPostalCode;
            ViewBag.NewUnit = newUnit;
            ViewBag.Province = newProvince;
            ViewBag.City = newCity;
            ViewBag.RecepientName = newRecepientName;
            ViewBag.Phone = newPhone;
            ViewBag.LandLinePhone = newLandLinePhone;
            ViewBag.FullAddress = newFullAddress;
            // edit address
            if (chooseAddress == 0)
            {
                // validation
                if (string.IsNullOrEmpty(recepientName) || string.IsNullOrEmpty(phone) || postalCode == null)
                {
                    ModelState.AddModelError("All", "جزئيات صورتحساب باید کامل باشند!");
                    return View(_CartService.DetailCart(userId));
                }
                if (phone.Length != 11)
                {
                    ModelState.AddModelError("All", "شماره موبایل باید ۱۱ رقم باشد!");
                    return View(_CartService.DetailCart(userId));
                }
                _addressService.UpdateAddressInCheckout(userAddress);
            }
            // add new address
            else
            {
                // validation
                if (string.IsNullOrEmpty(newRecepientName) || string.IsNullOrEmpty(newPhone) || newPostalCode == null
                    || newCity == 0 || newProvince == 0 || string.IsNullOrEmpty(newLandLinePhone) || newPlaque == 0
                    || newPostalCode == null || string.IsNullOrEmpty(newFullAddress))
                {
                    ModelState.AddModelError("All", "فیلد های ستاره دار ضروری هستند!");
                    return View(_CartService.DetailCart(userId));
                }
                if (newPhone.Length != 11 || newLandLinePhone.Length != 11)
                {
                    ModelState.AddModelError("All", "شماره موبایل و تلفن ثابت باید ۱۱ رقم باشد!");
                    return View(_CartService.DetailCart(userId));
                }
                useraddress address = new useraddress()
                {
                    userid = userId,
                    provinceid = newProvince,
                    cityid = newCity,
                    Recipientname = newRecepientName,
                    phone = newPhone,
                    Landlinephonenumber = newLandLinePhone,
                    Plaque = newPlaque,
                    postalCode = newPostalCode,
                    unit = newUnit,
                    FullAddress = newFullAddress
                };
                _addressService.addusraddress(address);
            }
            _CartService.UpdateCartDescription(userId, cartDescription);
            return Redirect("/Payment");
        }

        #region Comment
        public IActionResult Comment(int id)
        {
            ///var b = _productservice.ShowDetailsProduct(id);
            var detailproduct = _productservice.DetailProduct(id);
            var productprice = _productservice.GetProductprice(id);

            ViewBag.PropertyValue = _productservice.showValueForProduct(id);
            ViewBag.Galley = _productservice.showgalleryforproduct(id);
            if (detailproduct == null)
            {
                return NotFound();
            }
            ViewBag.Model = Tuple.Create(detailproduct, productprice);
            return View();
        }

        public IActionResult AddComment(comment comment)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            comment.userid = userid;
            _productservice.AddComment(comment);
            return Redirect("/Product/Detail/" + comment.productid);
        }
        [HttpPost]
        public IActionResult LikeComment(int commentId)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            _productservice.LikeComment(userid, commentId);
            return Ok();
        }
        [HttpPost]
        public IActionResult DislikeComment(int commentId)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            _productservice.DislikeComment(userid, commentId);
            return Ok();
        }
        #endregion

        #region Cart
        [HttpPost]
        [Route("AddCart/{id}/{productcount}")]
        public IActionResult AddCart(int id, int productcount)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(1);
            }
            int userid = int.Parse(User.FindFirst("userid").Value);
            int code = _CartService.AddCart(userid, id, productcount);
            return Json(code);
        }


        [HttpGet]
        [Authorize]
        [Route("basket")]
        public IActionResult basket(int code)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            var viewmodel = _CartService.DetailCart(userid);
            ViewBag.Code = code;
            return View(viewmodel);
        }

        [HttpPost]
        [Route("changecart")]
        public IActionResult changecart(int productpriceid, int count)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            _CartService.changebasket(userid, productpriceid, count);
            return Json(1);
        }

        [HttpGet]
        [Route("removeProductForBasket/{productpriceid}/{cartid}")]
        public IActionResult removeProductForBasket(int productpriceid, int cartid)
        {
            _CartService.RemoveProductForBasket(productpriceid, cartid);
            _Discountservice.RemoveDiscountFromCart(cartid);

            return RedirectToAction(nameof(basket));
        }


        [HttpPost]
        [Route("Discount")]
        public IActionResult Discount(string DiscountCode, int Cartid)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            int Code = _Discountservice.checkDiscount(Cartid, DiscountCode);

            return RedirectToAction(nameof(basket), new { code = Code });
        }

        #endregion

        #region Payment

        [HttpGet]
        [Route("Payment")]
        [Authorize]
        public IActionResult Payment()
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            Cart cart = _CartService.FindCartBuyeuserid(userid);

            //var zarinpal = new ZarinpalSandbox.Payment(cart.FinalPrice);
            //var result = zarinpal.PaymentRequest("پرداخت سبد خرید کالا مارکت", "https://localhost:44303/onlinepayment/" + cart.cartid);

            //if (result.Result.Status == 100)
            //{
            //    //  var a = result.Result.Link;
            //    //  var a1 = result.Result.Authority;

            //    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + result.Result.Authority);
            //    //  return Redirect(a);
            //}

          
            var paymentResponse =
                _zarinPalFactory.CreatePaymentRequest(cart.FinalPrice, "خرید از درگاه پرداخت بندر استور ", cart.cartid);


            return Redirect(
                $"https://{_zarinPalFactory.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");

        }

        
        public IActionResult onlinepayment(string id="")
        {

            var cartid = Convert.ToInt32(id);
            var cart = _CartService.findcartbuyeid(cartid);


            bool res = false;
            ViewBag.RefId = 0;
            ViewBag.PaymentDate = DateTime.Now.MilatiToShamsi();
            ViewBag.PaymentTime = DateTime.Now.TimeOfDay.ToString();
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                var authority = HttpContext.Request.Query["Authority"];



                var zarinpal = new ZarinpalSandbox.Payment(cart.FinalPrice);
                var result = zarinpal.Verification(authority).Result;

                if (result.Status == 100)
                {
                    res = true;
                    _productservice.AddProductSell(cartid);
                    _productservice.DecreaseProductCount(cartid);
                    cart.ispay = true;
                    cart.RefId = result.RefId.ToString();
                    ViewBag.RefId = cart.RefId;
                    _CartService.UpdateCart(cart);
                }
                cart.PaymentDate = DateTime.Now;
                ViewBag.PaymentDate = cart.PaymentDate.MilatiToShamsi();
                ViewBag.PaymentTime = cart.PaymentDate.TimeOfDay.ToString();
            }
            ViewBag.res = res;



            return View(_CartService.DetailCartForOnlinePayment(cartid));
        }
        public IActionResult CallBack([FromQuery] string authority, [FromQuery] string status,
            [FromQuery] string cartId)
        {

            var cart = int.Parse(cartId);
            var orderAmount = _productservice.GetAmountBy(cart).TotalPrice;
            if (orderAmount == 0) return BadRequest();
            
            var verificationResponse =
                _zarinPalFactory.CreateVerificationRequest(authority,
                    orderAmount.ToString());

            var result = new PaymentResult();
            if (status == "OK" && verificationResponse.Status >= 100)
            {
                var issueTrackingNo = _productservice.PaymentSucceeded(int.Parse(cartId), verificationResponse.RefID);
                result = result.Succeeded("پرداخت با موفقیت انجام شد.", issueTrackingNo,cartId);//تمامی پارامتر های که برای پرداخت موفق در ویو لازم داری رو از اینجا پاس بده به ویو
                return RedirectToAction("ResultPayment", result);
               
            }

            result = result.Failed(
                "پرداخت با موفقیت انجام نشد. درصورت کسر وجه از حساب، مبلغ تا 24 ساعت دیگر به حساب شما بازگردانده خواهد شد.", cartId);

            return RedirectToAction("ResultPayment", result);//تمامی پارامتر های که برای پرداخت ناموفق در ویو لازم داری رو از اینجا پاس بده به ویو
        }

        #endregion


       public IActionResult ResultPayment(PaymentResult resultPayment)
        {
            var cartId=int.Parse(resultPayment.CartId);
            var cart = _CartService.findcartbuyeid(cartId);

            //اینجا هیچ چیزیو چک نمیکنه فقط ویو رو نمایش بده
            //همه شرط ها و چیز های که باید چک بشود در اکشن های بالا چک شده 
           // اینجا فقط نتیجه پرداخت هست

            bool res = false;
            ViewBag.RefId = 0;
            ViewBag.PaymentDate = DateTime.Now.MilatiToShamsi();
            ViewBag.PaymentTime = DateTime.Now.TimeOfDay.ToString();
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                var authority = HttpContext.Request.Query["Authority"];



                var zarinpal = new ZarinpalSandbox.Payment(cart.FinalPrice);
                var result = zarinpal.Verification(authority).Result;

                if (result.Status == 100)
                {
                    res = true;
                    _productservice.AddProductSell(cartId);
                    _productservice.DecreaseProductCount(cartId);
                    cart.ispay = true;
                    cart.RefId = result.RefId.ToString();
                    ViewBag.RefId = cart.RefId;
                    _CartService.UpdateCart(cart);
                }
                cart.PaymentDate = DateTime.Now;
                ViewBag.PaymentDate = cart.PaymentDate.MilatiToShamsi();
                ViewBag.PaymentTime = cart.PaymentDate.TimeOfDay.ToString();
            }
            ViewBag.res = res;



            return View(resultPayment);
       
        }
        #region rate
        public IActionResult ShowRates(int id)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            ViewBag.HasUserRated = _productservice.HasUserRated(userid, id);
            ViewBag.Average = _productservice.GetAverageOfCommentScales(id);
            ViewBag.ProductId = id;
            ViewBag.ProductName = _productservice.findproductbuyeid(id).productFaTitle;
            return View();
        }
        public IActionResult AddRate(int productId, int star)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            _productservice.AddRate(userid, productId, star);
            return Redirect("/Product/Detail/" + productId);
        }
        #endregion
    }
}
