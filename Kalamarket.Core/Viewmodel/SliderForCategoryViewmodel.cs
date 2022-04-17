using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Viewmodel
{
    public class SliderForCategoryViewmodel
    {
        public int Productid { get; set; }
        public string productfatitle { get; set; }
        public string productimg { get; set; }
        public int mainprice { get; set; }
        public int? sepcialprice { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
