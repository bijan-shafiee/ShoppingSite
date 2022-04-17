using _98market.Core.Service.Interface;
using _98market.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _98market.DataLayer.Entities.DisCount;

namespace _98market.Core.Service
{
    public class DiscountService : IDiscountService
    {
        private _98marketContext _Context;
        private ICartService _CartService;
        public DiscountService(_98marketContext Context, ICartService CartService)
        {
            _Context = Context;
            _CartService = CartService;
        }

        public void AddDiscount(discount discount)
        {
            _Context.Add(discount);
            _Context.SaveChanges();
        }

        public int checkDiscount(int Cartid, string discountcode)
        {
            var Discount = _Context.discounts.FirstOrDefault(c => c.discountcode == discountcode);

            if (Discount == null)
                return 1;// کد تخفیف وارد شده نامعتبر می باشد .

            if (Discount.StartDate != null && Discount.StartDate > DateTime.Now)
                return 2; // تاریخ کد تخفیف هنوز آغاز نشده است

            if (Discount.EndDate != null && Discount.EndDate < DateTime.Now)
                return 3; // تاریخ کد تخفیف به پایان رسیده است

            if (Discount.Useablecount != null && Discount.Useablecount <= 0)
                return 4; //  تعداد کد تخفیف به پایان رسیده است .

            var cart = _Context.cart.Find(Cartid);

            if (_Context.UserDiscounts.Any(ud => ud.userid == cart.userid && ud.CartId == cart.cartid))
                return 7; // در هر سبد خرید فقط یکبار میشود از کد تخفیف استفاده کرد .

            if (cart.FinalPrice < Discount.MinPrice)
                    return Discount.MinPrice; // حداقل مبغ خرید برای استفاده از این کد تخفیف MinPrice می باشد .

            if (_Context.UserDiscounts.Any(c => c.userid == cart.userid && c.Discountid == Discount.discountid))
                return 5; // شما از قبل از این کد تخفیف استفاده کرده اید .

            int percent = (cart.TotalPrice * Discount.Discountpersent) / 100;

            cart.FinalPrice = cart.TotalPrice - percent;
            _CartService.UpdateCart(cart);

            if (Discount.Useablecount != null)
                Discount.Useablecount -= 1;

            _Context.Update(Discount);

            _Context.UserDiscounts.Add(new DataLayer.Entities.DisCount.UserDiscount
            {
                Discountid = Discount.discountid,
                userid = cart.userid,
                CartId = cart.cartid,
                CreateDate = DateTime.Now
            });
            _Context.SaveChanges();
            return 6; // کد تخفیف با موفقیت اعمال شد .
        }

        public void DeleteDiscount(int discountId)
        {
            discount discount = GetDiscount(discountId);
            discount.IsDelete = true;
            _Context.Update(discount);
            _Context.SaveChanges();
        }

        public void EditDiscount(discount discount)
        {
            _Context.Update(discount);
            _Context.SaveChanges();
        }

        public discount GetDiscount(int discountId)
        {
            return _Context.discounts.Find(discountId);
        }

        public List<discount> GetDiscounts()
        {
            return _Context.discounts.OrderByDescending(d => d.discountid).ToList();
        }

        public int RemoveDiscountFromCart(int cartId)
        {
            var cart = _Context.cart.Find(cartId);
            var userDiscount = _Context.UserDiscounts.Include(ud => ud.discount)
                .FirstOrDefault(ud => ud.CartId == cartId);
            if (userDiscount != null)
            {
                if (cart.FinalPrice < userDiscount.discount.MinPrice)
                {
                    _Context.UserDiscounts.Remove(userDiscount);
                    _Context.SaveChanges();
                }
            }
            return 1;
        }
    }
}
