using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Security
{
    public static class imagesecurity
    {
        public static string ImageSecurity(this IFormFile file)
        {
            try
            {
                System.Drawing.Image.FromStream(file.OpenReadStream());
                return "true";
            }
            catch (Exception)
            {
                return "false";
            }
        }
    }
}
