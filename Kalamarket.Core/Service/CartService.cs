using _98market.Core.Service.Interface;
using _98market.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using _98market.DataLayer.Entities;
using _98market.Core.Viewmodel;
using _98market.Core.ExtentionMethod;
using Microsoft.EntityFrameworkCore;
using _98market.DataLayer.Entities.Address;

namespace _98market.Core.Service
{
    public class CartService : ICartService
    {
        private _98marketContext _Context;
        public CartService(_98marketContext Context)
        {
            _Context = Context;
        }

        public int AddCart(int userid, int productid, int productcount)
        {
            Cart cart = _Context.cart.SingleOrDefault(c => !c.ispay && c.userid == userid);
            var product = _Context.ProductPrices.FirstOrDefault(c => c.Productpriceid == productid);

            if (cart == null)
            {
                cart = new Cart
                {
                    CreateDate = DateTime.Now.Date,
                    ispay = false,
                    RefId = "",
                    userid = userid,
                    TotalPrice = product.sepcialprice < product.mainprice && Convert.ToDateTime(product.EndDateDisCount).Date >= DateTime.Now.Date ? product.sepcialprice.Value : product.mainprice,

                    cartDetails = new List<CartDetail>
                    {
                        new CartDetail
                        {
                            count=productcount,
                            CreateDate=DateTime.Now.Date,
                            productid=productid,
                            price=product.sepcialprice < product.mainprice && Convert.ToDateTime(product.EndDateDisCount).Date >= DateTime.Now.Date ? product.sepcialprice.Value : product.mainprice,
                            PriceWithoutDiscount = product.mainprice
                        }
                    }
                };
                cart.TotalPrice *= productcount;
                cart.FinalPrice = cart.TotalPrice;
                _Context.Add(cart);
                _Context.SaveChanges();
                return 2;
            }
            else
            {
                CartDetail cartdetail =
                    _Context.CartDetail
                    .FirstOrDefault(c => c.Cartid == cart.cartid && c.productid == productid);

                if (cartdetail != null &&
                    (cartdetail.count + productcount) <= product.count
                    && (cartdetail.count + productcount) <= product.MaxorderCount)
                {
                    Decrease(cartdetail.Cartid, cartdetail.CartDetailid);
                    cartdetail.count += productcount;
                    _Context.CartDetail.Update(cartdetail);
                    sumprice(cartdetail.Cartid, cartdetail.CartDetailid);
                    return 2;
                }
                else if (cartdetail == null)
                {
                    cartdetail = new CartDetail
                    {
                        Cartid = cart.cartid,
                        count = productcount,
                        CreateDate = DateTime.Now.Date,
                        price = product.sepcialprice < product.mainprice && Convert.ToDateTime(product.EndDateDisCount).Date >= DateTime.Now.Date ? product.sepcialprice.Value : product.mainprice,
                        productid = productid,
                        PriceWithoutDiscount = product.mainprice
                    };
                    _Context.Add(cartdetail);
                    _Context.SaveChanges();
                    sumprice(cartdetail.Cartid, cartdetail.CartDetailid);
                    return 2;
                }

            }
            return 3;
        }
        public void sumprice(int cartid, int detailid)
        {
            var cart = _Context.cart.Find(cartid);
            var detail = _Context.CartDetail.FirstOrDefault(c => c.Cartid == cartid && c.CartDetailid == detailid);
            cart.TotalPrice += detail.count * detail.price;
            cart.FinalPrice = cart.TotalPrice;
            _Context.Update(cart);
            _Context.SaveChanges();
        }
        public void Decrease(int cartid, int detailid)
        {
            var cart = _Context.cart.Find(cartid);
            var detail = _Context.CartDetail.FirstOrDefault(c => c.Cartid == cartid && c.CartDetailid == detailid);
            if (detail != null) cart.TotalPrice -= detail.count * detail.price;
            cart.FinalPrice = cart.TotalPrice;
            _Context.Update(cart);
            _Context.SaveChanges();
        }

        public List<CartViewmodel> DetailCart(int userid)
        {
            List<CartViewmodel> carts = (from c in _Context.cart
                                         join cd in _Context.CartDetail on c.cartid equals cd.Cartid
                                         join pr in _Context.ProductPrices on cd.productid equals pr.Productpriceid
                                         join p in _Context.products on pr.productid equals p.productid
                                         join color in _Context.ProductColors on pr.productcolorid equals color.colorid
                                         join g in _Context.productGurantees on pr.productguranteeid equals g.GuranteeId
                                         where (c.userid == userid && !c.ispay)
                                         select new CartViewmodel
                                         {
                                             Colorname = color.colorname,
                                             guranteename = g.guranteename,
                                             ordercount = cd.count,
                                             productFaTitle = p.productFaTitle,
                                             Productid = p.productid,
                                             ProductPrice = cd.price,
                                             productpriceid = pr.Productpriceid,
                                             productimage = p.Productimage,
                                             TotalPrice = c.TotalPrice,
                                             FinalPrice = c.FinalPrice,
                                             PriceWithoutDiscount = cd.PriceWithoutDiscount,
                                             Maxordercount = pr.MaxorderCount,
                                             productcount = pr.count,
                                             Cartid = cd.Cartid,
                                             ColorCode = color.ColorCode,
                                         }).ToList();
            return carts;
        }


        public int changebasket(int userid, int productid, int count)
        {
            Cart cart = _Context.cart.SingleOrDefault(c => !c.ispay && c.userid == userid);
            var product = _Context.ProductPrices.FirstOrDefault(c => c.Productpriceid == productid);

            if (cart == null)
            {
                cart = new Cart
                {
                    CreateDate = DateTime.Now.Date,
                    ispay = false,
                    RefId = "",
                    userid = userid,
                    TotalPrice = product.sepcialprice < product.mainprice && Convert.ToDateTime(product.EndDateDisCount).Date < DateTime.Now.Date ? product.sepcialprice.Value : product.mainprice,

                    cartDetails = new List<CartDetail>
                    {
                        new CartDetail
                        {
                            count=count,
                            CreateDate=DateTime.Now.Date,
                            productid=productid,
                            price=product.sepcialprice < product.mainprice && Convert.ToDateTime(product.EndDateDisCount).Date < DateTime.Now.Date ? product.sepcialprice.Value : product.mainprice,
                            PriceWithoutDiscount = product.mainprice
                        }
                    }
                };
                _Context.Add(cart);
                _Context.SaveChanges();
                return 2;
            }
            else
            {
                CartDetail cartdetail = _Context.CartDetail.FirstOrDefault(c => c.Cartid == cart.cartid && c.productid == product.Productpriceid);

                if (cartdetail != null && cartdetail.count <= product.MaxorderCount)
                {
                    Decrease(cartdetail.Cartid, cartdetail.CartDetailid);
                    cartdetail.count = count;
                    _Context.CartDetail.Update(cartdetail);
                    sumprice(cartdetail.Cartid, cartdetail.CartDetailid);
                    return 2;
                }
                else if (cartdetail == null)
                {
                    cartdetail = new CartDetail
                    {
                        Cartid = cart.cartid,
                        count = count,
                        CreateDate = DateTime.Now.Date,
                        price = product.sepcialprice < product.mainprice && Convert.ToDateTime(product.EndDateDisCount).Date < DateTime.Now.Date ? product.sepcialprice.Value : product.mainprice,
                        productid = productid,
                    };
                    _Context.Add(cartdetail);
                    _Context.SaveChanges();
                    sumprice(cartdetail.Cartid, cartdetail.CartDetailid);
                    return 2;
                }

            }
            return 3;
        }

        public void RemoveProductForBasket(int productpriceid, int cartid)
        {
            var basket = _Context.CartDetail.FirstOrDefault(c => c.productid == productpriceid && c.Cartid == cartid);
           
            if (basket != null)
            {
                Decrease(basket.Cartid, basket.CartDetailid);
                _Context.Remove(basket);
                _Context.SaveChanges();
            }

            basket = _Context.CartDetail.FirstOrDefault(c => c.productid == productpriceid && c.Cartid == cartid);
          
            if (basket == null) return;

            _Context.Remove(_Context.cart.Find(cartid));
            var userDiscount = _Context.UserDiscounts.FirstOrDefault(ud => ud.CartId == cartid);
            if (userDiscount != null)
                _Context.UserDiscounts.Remove(userDiscount);
            _Context.SaveChanges();
        }
        public void UpdateCart(Cart cart)
        {
            _Context.Update(cart);
            _Context.SaveChanges();
        }

        public Cart FindCartBuyeuserid(int userid)
        {
            return _Context.cart.Where(c => !c.ispay && c.userid == userid).FirstOrDefault();
        }

        public Cart findcartbuyeid(int cartid)
        {
            return _Context.cart.Find(cartid);
        }

        public List<hichartViewmodel> hichart()
        {
            var chart = _Context.cart.Where(c => c.ispay).GroupBy(c => c.CreateDate.Date).OrderByDescending(c => c.Key).Take(7).Select(c => new hichartViewmodel
            {

                name = c.Key.MilatiToShamsi(),
                y = c.Count()

            }).ToList();
            //var chart = _Context.cart.Select(c=>new hichartViewmodel { 

            //name =c.CreateDate.ToString(),
            //y=c.cartid,

            //}).ToList();
            return chart.OrderBy(c => c.name).ToList();
        }

        public List<ShowBasketViewmodel> ShowAllProductForBasket(int userid)
        {
            return (from c in _Context.cart
                    where (c.userid == userid && !c.ispay)
                    join cd in _Context.CartDetail on c.cartid equals cd.Cartid

                    join pr in _Context.ProductPrices on cd.productid equals pr.Productpriceid
                    join p in _Context.products on pr.productid equals p.productid

                    select new ShowBasketViewmodel
                    {
                        Mainprice =
                        (pr.mainprice > pr.sepcialprice &&
                        pr.EndDateDisCount >= DateTime.Now.Date)
                        ? pr.sepcialprice : pr.mainprice,

                        productfaTitle = p.productFaTitle,
                        productid = p.productid,
                        productimage = p.Productimage,
                        totalbasket = c.TotalPrice,

                    }).ToList();

        }

        public List<showpostedViewmodel> Showposteds()
        {
            var b = _Context.cart
                .Include(c => c.user)
                .Select(x => new showpostedViewmodel
                {
                    cartid = x.cartid,
                    DateTime = x.CreateDate,
                    email = x.user.email,
                    TotalPrice = x.TotalPrice,
                    Status = x.Status,
                    TrackingCode = x.TrackingCode
                }).ToList();
            return b;

        }

        public List<DetailpostedViewmodel> Detailposteds(int cartid)
        {
            var detail = (from ct in _Context.cart
                          join cd in _Context.CartDetail on ct.cartid equals cd.Cartid

                          join pr in _Context.ProductPrices on cd.productid equals pr.Productpriceid
                          join p in _Context.products on pr.productid equals p.productid
                          join c in _Context.ProductColors on pr.productcolorid equals c.colorid
                          join g in _Context.productGurantees on pr.productguranteeid equals g.GuranteeId

                          join u in _Context.users on ct.userid equals u.userid
                          join ua in _Context.useraddresses on u.userid equals ua.userid
                          join province in _Context.provinces on ua.provinceid equals province.provinceid
                          join citi in _Context.cities on ua.cityid equals citi.cityid

                          where (ct.cartid == cartid && (!ua.Isdelete && ua.userid == ct.userid))
                          select new DetailpostedViewmodel
                          {
                              Address = province.provincename + "-" + citi.cityname + "-" + ua.FullAddress,
                              colorname = c.colorname,
                              gurantename = g.guranteename,
                              productid = p.productid,
                              productimage = p.Productimage,
                              productname = p.productFaTitle,
                              productprice = cd.price,
                              Count = cd.count,
                              FinalPrice = ct.FinalPrice

                          }).ToList();
            return detail;

        }

        public void Send(int cartid)
        {
            var cart = _Context.cart.Find(cartid);
            cart.Status = 3;
            _Context.SaveChanges();
        }


        public bool ExistAddress(int userid)
        {
            return _Context.useraddresses.Any(x => x.userid == userid && !x.Isdelete);
        }

        public void UpdateCartDescription(int userId, string description)
        {
            Cart cart = _Context.cart.FirstOrDefault(c => c.userid == userId && !c.ispay);
            cart.Description = description;
            _Context.cart.Update(cart);
            _Context.SaveChanges();
        }

        public List<CartViewmodel> DetailCartForOnlinePayment(int cartId)
        {
            List<CartViewmodel> carts = (from c in _Context.cart
                                         join cd in _Context.CartDetail on c.cartid equals cd.Cartid
                                         join pr in _Context.ProductPrices on cd.productid equals pr.Productpriceid
                                         join p in _Context.products on pr.productid equals p.productid
                                         join color in _Context.ProductColors on pr.productcolorid equals color.colorid
                                         join g in _Context.productGurantees on pr.productguranteeid equals g.GuranteeId
                                         where (c.cartid == cartId)
                                         select new CartViewmodel
                                         {
                                             Colorname = color.colorname,
                                             guranteename = g.guranteename,
                                             ordercount = cd.count,
                                             productFaTitle = p.productFaTitle,
                                             Productid = p.productid,
                                             ProductPrice = cd.price,
                                             productpriceid = pr.Productpriceid,
                                             productimage = p.Productimage,
                                             TotalPrice = c.TotalPrice,
                                             PriceWithoutDiscount = cd.PriceWithoutDiscount,
                                             Maxordercount = pr.MaxorderCount,
                                             productcount = pr.count,
                                             Cartid = cd.Cartid,
                                             ColorCode = color.ColorCode,
                                         }).ToList();
            return carts;
        }

        public void Accept(int cartId)
        {
            var cart = _Context.cart.Find(cartId);
            cart.Status = 1;
            _Context.SaveChanges();
        }

        public void ReadyToSend(int cartId)
        {
            var cart = _Context.cart.Find(cartId);
            cart.Status = 2;
            _Context.SaveChanges();
        }

        public void Received(int cartId)
        {
            var cart = _Context.cart.Find(cartId);
            cart.Status = 4;
            _Context.SaveChanges();
        }

        public void SetTrackingCode(int cartId, string trackingCode)
        {
            var cart = _Context.cart.Find(cartId);
            cart.TrackingCode = trackingCode;
            _Context.SaveChanges();
        }

        public ReceiverPostViewModel GetReceiverPost(int cartId)
        {
            Cart cart = _Context.cart.Find(cartId);
            user user = _Context.users.Find(cart.userid);
            useraddress address = _Context.useraddresses.Include(ua => ua.province).Include(ua => ua.city)
                .FirstOrDefault(ua => ua.userid == user.userid);
            return new ReceiverPostViewModel()
            {
                Name = user.userAccount,
                Mobile = address.phone,
                Phone = address.Landlinephonenumber,
                Province = address.province.provincename,
                City = address.city.cityname,
                PostalCode = address.postalCode,
                Plaque = address.Plaque,
                Unit = address.unit,
                Address = address.FullAddress
            };
        }
    }
}
