using _98market.Core.ExtentionMethod;
using _98market.Core.Security;
using _98market.Core.Service.Interface;
using _98market.Core.Viewmodel;
using _98market.DataLayer.Entities.DisCount;
using _98market.DataLayer.Entities.Entitieproduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _98market.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckPermission(1)]
    public class ProductController : Controller
    {
        private readonly Iproductservice _productservice;
        private ICategoryService _Categoryservice;
        private IBrandService _brandservice;
        private IguranteeService _Guranteeservice;
        private ICartService _CartService;
        private IDiscountService _discountService;
        public ProductController(Iproductservice productservice, ICategoryService Categoryservice,
            IBrandService brandservice, IguranteeService Guranteeservice,
            ICartService CartService, IDiscountService discountService)
        {
            _productservice = productservice;
            _Categoryservice = Categoryservice;
            _brandservice = brandservice;
            _Guranteeservice = Guranteeservice;
            _CartService = CartService;
            _discountService = discountService;
        }

        #region PropertyColor
        public IActionResult ShowAllColor()
        {
            return View(_productservice.showallColor());
        }

        [HttpGet]
        public IActionResult AddColor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddColor(productColor productColor)
        {
            if (!ModelState.IsValid)
                return View(productColor);
            if (_productservice.ExistColor(productColor.colorname, productColor.ColorCode, 0))
            {
                ModelState.AddModelError("ErrorColor", "رنگ انتخابی تکراری است .");
                return View(productColor);
            }
            int colorid = _productservice.AddColor(productColor);
            TempData["Result"] = colorid > 0 ? "true" : "false";
            return RedirectToAction(nameof(ShowAllColor));
        }


        [HttpGet]
        public IActionResult UpdateColor(int id)
        {
            productColor productColor = _productservice.findcolorbuyeid(id);
            if (productColor == null)
            {
                return NotFound();
            }
            return View(productColor);
        }

        [HttpPost]
        public IActionResult UpdateColor(productColor productColor)
        {
            if (!ModelState.IsValid)
            {
                return View(productColor);
            }
            if (_productservice.ExistColor(productColor.colorname, productColor.ColorCode, productColor.colorid))
            {
                ModelState.AddModelError("ErrorColor", "رنگ انتخابی تکراری است .");
                return View(productColor);
            }
            bool res = _productservice.updateColor(productColor);
            TempData["Result"] = res ? "true" : "false";
            return RedirectToAction(nameof(ShowAllColor));

        }
        [HttpGet]
        public IActionResult DeleteColor(int id)
        {
            productColor productColor = _productservice.findcolorbuyeid(id);
            if (productColor == null)
            {
                TempData["NotFoundColor"] = "true";
                return RedirectToAction(nameof(Index));
            }
            return View(productColor);
        }
        #endregion

        #region Propertyname

        public IActionResult ShowAllPropertyname()
        {

            return View(_productservice.ShowAllProperty());
        }

        public IActionResult ActiveFilter(int id)
        {
            _productservice.ActiveFelter(id);
            return RedirectToAction("ShowAllPropertyname");//action index
        }
        public IActionResult DeActiveFilter(int id)
        {
            _productservice.DeActiveFelter(id);
            return RedirectToAction("ShowAllPropertyname");//action index
        }
        [HttpGet]
        public IActionResult AddPropertyname()
        {
            ViewBag.Category = _Categoryservice.Showsubcategory();
            return View();
        }
        [HttpPost]
        public IActionResult AddPropertyname(PropertyName propertyName, List<int> Categoryid)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Category = _Categoryservice.Showsubcategory();
                return View(propertyName);
            }
            if (_productservice.ExistPropertyname(propertyName.PropertyTitle, 0))
            {
                ModelState.AddModelError("PropertyTitle", "خصوصیات تکراری است .");
                return View(propertyName);
            }
            int nameid = _productservice.AddPropertyname(propertyName);
            if (nameid <= 0)
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllPropertyname));
            }
            List<Propertyname_Category> Addpc = new List<Propertyname_Category>();

            foreach (var item in Categoryid)
            {
                Addpc.Add(new Propertyname_Category
                {
                    Categoryid = item,
                    PropertyNameId = nameid,

                });
            }

            bool res = _productservice.AddPropertyForCategory(Addpc);
            TempData["Result"] = res ? "true" : "false";
            return RedirectToAction(nameof(ShowAllPropertyname));
        }

        [HttpGet]
        public IActionResult UpdateProperty(int id)
        {
            ViewBag.Category = _Categoryservice.Showsubcategory();
            ViewBag.Property = _productservice.ShowpropertynameForUpdate(id);
            return View(_productservice.findpropbuyeid(id));
        }

        [HttpPost]
        public IActionResult UpdateProperty(PropertyName propertyName, List<int> Categoryid)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Category = _Categoryservice.Showsubcategory();
                ViewBag.Property = _productservice.ShowpropertynameForUpdate(propertyName.PropertyNameId);
                return View();
            }
            if (_productservice.ExistPropertyname(propertyName.PropertyTitle, propertyName.PropertyNameId))
            {
                ModelState.AddModelError("PropertyTitle", "خصوصیات تکراری است .");
                return View(propertyName);
            }
            bool updateprop = _productservice.UpdatePropertyname(propertyName);
            if (!updateprop)
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllPropertyname));
            }
            bool deleteprop = _productservice.DeleteProperyForCategory(propertyName.PropertyNameId);
            if (!deleteprop)
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllPropertyname));
            }
            List<Propertyname_Category> categories = new List<Propertyname_Category>();
            foreach (var item in Categoryid)
            {
                categories.Add(new Propertyname_Category
                {
                    Categoryid = item,
                    PropertyNameId = propertyName.PropertyNameId,

                });
            }
            bool addpropertyforcategory = _productservice.AddPropertyForCategory(categories);
            TempData["Result"] = addpropertyforcategory ? "true" : "false";
            return RedirectToAction(nameof(ShowAllPropertyname));
        }
        #endregion

        #region Product

        public IActionResult ShowAllProduct()
        {
            return View(_productservice.ShowallProduct());
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Category = _Categoryservice.Showsubcategory();
            ViewBag.brand = _brandservice.ShowAllBrand();
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(product product, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Category = _Categoryservice.Showsubcategory();
                ViewBag.brand = _brandservice.ShowAllBrand();
                return View(product);
            }
            if (file == null)
            {
                ModelState.AddModelError("SliderImg", "لطفا یک تصویر برای اسلایدر انتخاب نمایید .");
                return View(product);

            }

            string imgname = UploadImgProduct.CreateImage(file);
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllProduct));
            }
            
            product.Productimage = imgname;
            product.ProductCreate = DateTime.Now;
            int productid = _productservice.AddProduct(product);
            TempData["Result"] = productid > 0 ? "true" : "false";
            return RedirectToAction(nameof(ShowAllProduct));

        }


        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            product update = _productservice.findproductbuyeid(id);
            if (update == null)
            {
                return NotFound();
            }
            ViewBag.Category = _Categoryservice.Showsubcategory();
            ViewBag.brand = _brandservice.ShowAllBrand();

            return View(update);
        }

        [HttpPost]
        public IActionResult UpdateProduct(product product, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Category = _Categoryservice.Showsubcategory();
                ViewBag.brand = _brandservice.ShowAllBrand();
                return View(product);
            }
             if (file != null)
            {
               string imgname = UploadImgProduct.CreateImage(file);
                if (imgname == "false")
                {
                    TempData["Result"] = "false";
                    return RedirectToAction(nameof(Index));
                }
                bool DeleteImage = UploadImgProduct.DeleteImg("ImageSite", product.Productimage);
                if (!DeleteImage)
                {
                    TempData["Result"] = "false";
                    return RedirectToAction(nameof(Index));
                }
                product.Productimage = imgname;

            }
            product.ProductUpdate = DateTime.Now;
            bool update = _productservice.UpdateProduct(product);
            TempData["Result"] = update ? "true" : "false";
            return RedirectToAction(nameof(ShowAllProduct));

        }
        public IActionResult DeleteProduct(int id)
        {
            _productservice.DeleteProduct(id);
            return RedirectToAction(nameof(ShowAllProduct));
        }

        [HttpGet]
        public IActionResult ShowPropertynameForProduct(int id)
        {
            int categoryid = _productservice.FindCategoryForProduct(id);
            ViewBag.propertyname = _productservice.showallpropertyforcategory(categoryid);
            ViewBag.propertyvalue = _productservice.showpropertyvalueforproduct(id);
            TempData["productid"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddPropertyForProduct(List<int> nameid, List<string> value)
        {
            int productid = int.Parse(TempData["productid"].ToString());
            if (nameid.Count != value.Count)
            {
                int categoryid = _productservice.FindCategoryForProduct(productid);
                ViewBag.propertyname = _productservice.showallpropertyforcategory(categoryid);
                ViewBag.propertyvalue = _productservice.showpropertyvalueforproduct(productid);
                TempData["productid"] = productid;
                return View("ShowPropertynameForProduct");
            }
            List<PropertyValue> propertyValues = new List<PropertyValue>();

            for (int i = 0; i < nameid.Count; i++)
            {
                propertyValues.Add(new PropertyValue
                {
                    productid = productid,
                    propertyvalue = value[i],
                    propertynameid = nameid[i],

                });
            }
            List<PropertyValue> PropertyValue = propertyValues.Where(p => p.propertyvalue != null).ToList();
            bool res = _productservice.AddOrUpdatePropertynameForProduct(PropertyValue, productid);
            TempData["Result"] = res ? "true" : "false";
            return RedirectToAction(nameof(ShowAllProduct));
        }

        public IActionResult ShowAllPrice(int id)
        {
            ViewBag.id = id;
            return View(_productservice.ShowAllPriceForProduct(id));
        }

        public IActionResult AddPrice(int id)
        {
            ViewBag.Gurantee = _Guranteeservice.ShowAllGurantee();
            ViewBag.Color = _productservice.showallColor();
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddPrice(AddOrUpdateProductpriceviewmodel productPrice)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Gurantee = _Guranteeservice.ShowAllGurantee();
                ViewBag.Color = _productservice.showallColor();
                ViewBag.id = productPrice.productid;
                return View(productPrice);
            }
            ProductPrice product = new ProductPrice
            {
                count = productPrice.count,
                Createdate = DateTime.Now,
                EndDateDisCount = productPrice.EndDateDisCount.ShamsiToMiladi(),
                mainprice = productPrice.mainprice,
                MaxorderCount = productPrice.MaxorderCount,
                productcolorid = productPrice.productcolorid,
                productguranteeid = productPrice.productguranteeid,
                productid = productPrice.productid,
                sepcialprice = productPrice.sepcialprice,
                Productpriceid = productPrice.Productpriceid,
            };
            int priceid = _productservice.AddPriceForProduct(product);
            TempData["Result"] = priceid > 0 ? "true" : "false";
            return RedirectToAction(nameof(ShowAllProduct));

        }
        public IActionResult ActivePrice(int id)
        {
            _productservice.ActivePrice(id);
            return RedirectToAction(nameof(ShowAllPrice));//action index
        }
        public IActionResult DeActivePrice(int id)
        {
            _productservice.DeActivePrice(id);
            return RedirectToAction(nameof(ShowAllPrice));//action index
        }
        #endregion

        #region review

        public IActionResult ShowReview(int id)
        {
            ViewBag.review = _productservice.findreviewbuyeid(id);
            TempData["productid"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddReview(List<string> posative, List<string> negative, Review review)
        {
            int productid = int.Parse(TempData["productid"].ToString());
            if (!ModelState.IsValid)
            {
                ViewBag.review = _productservice.findreviewbuyeid(productid);
                TempData["productid"] = productid;
                return View(review);
            }
            bool DeleteReview = _productservice.Deletereview(productid);
            if (!DeleteReview)
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllProduct));
            }
            Review AddReview = new Review()
            {
                ArticleDescription = review.ArticleDescription,
                AticleTitle = review.AticleTitle,
                reviewDescription = review.reviewDescription,
                Reviewnegative = string.Join("^", negative),
                ReviewPositive = string.Join("^", posative),
            };

            if (AddReview.reviewDescription != null ||
                AddReview.AticleTitle != null ||
                AddReview.ArticleDescription != null ||
                (!String.IsNullOrEmpty(AddReview.ReviewPositive) || !String.IsNullOrEmpty(AddReview.Reviewnegative)))
            {

                AddReview.productid = productid;
                bool addreview = _productservice.AddOrupdatereview(AddReview);
                TempData["Result"] = addreview ? "true" : "false";
                return RedirectToAction(nameof(ShowAllProduct));
            }
            TempData["Result"] = DeleteReview ? "true" : "false";
            return RedirectToAction(nameof(ShowAllProduct));

        }

        #endregion


        #region Posted

        [Route("showposted")]
        public IActionResult showposted()
        {
            return View(_CartService.Showposteds());
        }

        [Route("DetailPosted/{id}")]
        public IActionResult DetailPosted(int id)
        {
            ViewBag.Receiver = _CartService.GetReceiverPost(id);
            return View(_CartService.Detailposteds(id));
        }
        [Route("Accept/{id}")]
        public IActionResult Accept(int id)
        {
            _CartService.Accept(id);
            return RedirectToAction(nameof(showposted));
        }
        [Route("Send/{id}")]
        public IActionResult Send(int id)
        {
            _CartService.Send(id);
            return RedirectToAction(nameof(showposted));
        }
        [Route("ReadyToSend/{id}")]
        public IActionResult ReadyToSend(int id)
        {
            _CartService.ReadyToSend(id);
            return RedirectToAction(nameof(showposted));
        }
        [Route("Received/{id}")]
        public IActionResult Received(int id)
        {
            _CartService.Received(id);
            return RedirectToAction(nameof(showposted));
        }
        [Route("SetTrackingCode/{id}/{trackingCode}")]
        public IActionResult SetTrackingCode(int id, string trackingCode)
        {
            _CartService.SetTrackingCode(id, trackingCode);
            return RedirectToAction(nameof(showposted));
        }
        #endregion

        #region Discounts
        public IActionResult Discounts()
        {
            return View(_discountService.GetDiscounts());
        }
        [HttpGet]
        public IActionResult AddDiscount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDiscount(discount discount, string startDate = "", string endDate = "")
        {
            discount.StartDate = startDate.ShamsiToMiladi();
            discount.EndDate = endDate.ShamsiToMiladi();
            _discountService.AddDiscount(discount);
            return Redirect("/admin/product/discounts");
        }
        [HttpGet]
        public IActionResult EditDiscount(int id)
        {
            return View(_discountService.GetDiscount(id));
        }
        [HttpPost]
        public IActionResult EditDiscount(discount discount, string startDate = "", string endDate = "")
        {
            if (discount.StartDate.Value.MilatiToShamsi() != startDate)
                discount.StartDate = startDate.ShamsiToMiladi();
            if (discount.EndDate.Value.MilatiToShamsi() != endDate)
                discount.EndDate = endDate.ShamsiToMiladi();
            _discountService.EditDiscount(discount);
            return Redirect("/admin/product/discounts");
        }
        public IActionResult DeleteDiscount(int id)
        {
            _discountService.DeleteDiscount(id);
            return Redirect("/admin/product/discounts");
        }
        #endregion

        #region Gallery
        public IActionResult Galleries(int id)
        {
            ViewBag.productId = id;
            return View(_productservice.showgalleryforproduct(id));
        }
        [HttpGet]
        public IActionResult AddGallery(int id)
        {
            ViewBag.productId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddGallery(ProductGallery gallery, IFormFile file)
        {
            ViewBag.productId = gallery.productid;
            if (file == null)
            {
                ModelState.AddModelError("All", "لطفا یک تصویر انتخاب نمایید .");
                return View(gallery);
            }

            string imgname = UploadImgProduct.CreateImage(file);
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Galleries));
            }
            gallery.imagename = imgname;
            _productservice.AddGallery(gallery);
            return Redirect("/admin/product/galleries/" + gallery.productid);
        }
        [HttpGet]
        public IActionResult EditGallery(int id)
        {
            return View(_productservice.GetGallery(id));
        }
        [HttpPost]
        public IActionResult EditGallery(ProductGallery gallery, IFormFile file)
        {
            if (file == null)
            {
                ModelState.AddModelError("All", "لطفا یک تصویر انتخاب نمایید .");
                return View(gallery);
            }

            string imgname = UploadImgProduct.CreateImage(file);
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Galleries));
            }
            gallery.imagename = imgname;
            _productservice.EditGallery(gallery);
            return Redirect("/admin/product/galleries/" + gallery.productid);
        }
        public IActionResult DeleteGallery(int id)
        {
            int productId = _productservice.DeleteGallery(id);
            return Redirect("/admin/product/galleries/" + productId);
        }
        #endregion

    }
}
