using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Viewmodel
{
    public class showpostedViewmodel
    {
        public int cartid { get; set; }
        public string email { get; set; }
        public DateTime DateTime { get; set; }
        public int TotalPrice { get; set; }
        public int Status { get; set; }
        public string TrackingCode { get; set; }
    }

    public class DetailpostedViewmodel
    {
        public int productid { get; set; }
        public string productimage { get; set; }
        public string productname { get; set; }
        public int productprice { get; set; }
        public string gurantename { get; set; }
        public string colorname { get; set; }
        public string Address { get; set; }
        public int Count { get; set; }
        public long FinalPrice { get; set; }
    }
    public class ReceiverPostViewModel
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int Plaque { get; set; }
        public int Unit { get; set; }
        public string Address { get; set; }
    }
}
