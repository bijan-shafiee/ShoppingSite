using _98market.Core.Viewmodel;
using _98market.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Service.Interface
{
    public interface ICartService
    {
        int AddCart(int userid, int productid , int productcount);
        List<CartViewmodel> DetailCart(int userid);
        int changebasket(int userid, int productid, int count);
        void RemoveProductForBasket(int productpriceid, int cartid);
        void UpdateCart(Cart cart);
        Cart FindCartBuyeuserid(int userid);
        Cart findcartbuyeid(int cartid);
        List<hichartViewmodel> hichart();
        List<ShowBasketViewmodel> ShowAllProductForBasket(int userid);
        List<DetailpostedViewmodel> Detailposteds(int cartid);
        List<showpostedViewmodel> Showposteds();
        void Send(int cartid);
        void Accept(int cartId);
        void ReadyToSend(int cartId);
        void Received(int cartId);
        void SetTrackingCode(int cartId, string trackingCode);
        void UpdateCartDescription(int userId, string description);
        List<CartViewmodel> DetailCartForOnlinePayment(int cartId);
        ReceiverPostViewModel GetReceiverPost(int cartId);
    }
}
