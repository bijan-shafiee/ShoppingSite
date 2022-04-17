using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Viewmodel
{
    public class sepcialProductViewmoddel
    {
        public int productid { get; set; }

        public string productfatitle { get; set; }
        public string productimg { get; set; }
        public int mainprice { get; set; }
        public int? sepcialprice { get; set; }
        public List<ValueViewmodel> ValuesList { get; set; }
        public DateTime? Endsepcialprice { get; set; }
        public int productpriceid { get; set; }

    }

    public class ValueViewmodel
    {
        public string propname { get; set; }
        public string value { get; set; }
    }
}
