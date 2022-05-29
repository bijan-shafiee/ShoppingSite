//using _98market.DataLayer.Entities.Entitieproduct;
using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Service.Interface
{
    public interface ITrackingPriceService
    {
        List<TrackingPriceService> ShowAllTrackingPrice();
        int AddTrackingPrice(TrackingPriceService TrackingPrice);
        TrackingPriceService GetTrackingPrice(int TrackingPriceId);
        int UpdateTrackingPrice(TrackingPriceService TrackingPrice);
        void ActiveTrackingPrice(int TrackingPriceId);
        void DeActiveTrackingPrice(int TrackingPriceId);
    }
}
