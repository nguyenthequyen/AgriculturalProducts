using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Models.Common
{
    public static class ConvertBase64
    {
        public static string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}
