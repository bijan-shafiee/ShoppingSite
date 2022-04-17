using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Viewmodel
{
    public class DetailProductViewmodel
    {
        public int productid { get; set; }
        public string productfatitle { get; set; }
        public string productentitle { get; set; }
        public int productsell { get; set; }
        public int CategoryId { get; set; }
        public string categoryname { get; set; }
        public string producttag { get; set; }
        public int BrandId { get; set; }
        public string productbrand { get; set; }
        public string productimage { get; set; }
        public byte productstar { get; set; }
    }
    public class productpricevm
    {
        public int productpriceid { get; set; }
        public string colorname { get; set; }
        public string colorcode { get; set; }
        public string guranteename { get; set; }
        public int mainprice { get; set; }
        public int? sepcialprice { get; set; }
        public int count { get; set; }
        public int maxordercount { get; set; }
        public DateTime? enddiscount { get; set; }

    }
}
