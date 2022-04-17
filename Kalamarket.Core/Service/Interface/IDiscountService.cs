using _98market.DataLayer.Entities.DisCount;
using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Service.Interface
{
    public interface IDiscountService
    {
        int checkDiscount(int Cartid, string discountcode);
        int RemoveDiscountFromCart(int cartId);
        List<discount> GetDiscounts();
        discount GetDiscount(int discountId);
        void EditDiscount(discount discount);
        void DeleteDiscount(int discountId);
        void AddDiscount(discount discount);
    }
}
