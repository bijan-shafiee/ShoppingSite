using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Viewmodel
{
    public class ShowDetailorder
    {
        public int cartid { get; set; }
        public int productid { get; set; }
        public string productFaTitle { get; set; }
        public int price { get; set; }
        public int Totalprice { get; set; }
        public int Status { get; set; }
        public string TrackingCode { get; set; }

    }
}
