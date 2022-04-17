using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Viewmodel
{
   public class CartViewmodel
    {
        public int Productid { get; set; }

        public int productpriceid { get; set; }
        public string productFaTitle { get; set; }

        public string Colorname { get; set; }
        public string ColorCode { get; set; }
        public string guranteename { get; set; }
        public int ordercount { get; set; }

        public int ProductPrice { get; set; }

        public int Maxordercount { get; set; }
        public int productcount { get; set; }
        public string productimage { get; set; }
        public long PriceWithoutDiscount { get; set; }
        public int TotalPrice { get; set; }
        public int FinalPrice { get; set; }
        public int Cartid { get; set; }
    }
}
