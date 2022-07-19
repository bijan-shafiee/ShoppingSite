using _98market.Core.Service.Interface;
using _98market.DataLayer.Context;
using _98market.DataLayer.Entities.Entitieproduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _98market.Core.Service
{
    public class TrackingPriceService : ITrackingPriceService
    {
        private _98marketContext _Context;
        public TrackingPriceService(_98marketContext Context)
        {
            _Context = Context;
        }

        public int AddTrackingPrice(TrackingPriceService TrackingPrice)
        {
            return 0;
        }

        public TrackingPriceService GetTrackingPrice(int TrackingPriceId)
        {
            return null;
        }

        public List<TrackingPriceService> ShowAllTrackingPrice()
        {

            return null;
        }
       

        public int UpdateTrackingPrice(TrackingPriceService TrackingPrice)
        {
           return 0;
        }
        public void ActiveTrackingPrice(int id)
        {
           
        }
        public void DeActiveTrackingPrice(int id)
        {
        }
    }
}

