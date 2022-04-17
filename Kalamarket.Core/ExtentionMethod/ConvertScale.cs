using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.ExtentionMethod
{
    public static class ConvertScale
    {
        public static string CommentScale(this int value)
        {
            string scale = "";
            switch (value)
            {
                case 1:
                    scale = "خیلی بد";
                    break;
                case 2:
                    scale = "بد";
                    break;
                case 3:
                    scale = "معمولی";
                    break;
                case 4:
                    scale = "خوب";
                    break;
                case 5:
                    scale = "عالی";
                    break;
            }
            return scale;
        }
    }
}
