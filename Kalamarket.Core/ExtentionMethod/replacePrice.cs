using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.ExtentionMethod
{
   public static class ReplacePrice
    {
        public static int replacePrice(this string price)
        {
            int Price = 0;
            if (!String.IsNullOrEmpty(price))
            {
                Price =int.Parse(price.Replace(",", ""));
            }
            return Price;
        }
    }
}
