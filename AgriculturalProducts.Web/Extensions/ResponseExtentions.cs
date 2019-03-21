using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturalProducts.API
{
    public static class ResponseExtentions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", Strings.RemoveAllNonPrintableCharacters(message));
            // CORS
            response.Headers.Add("access-control-expose-headers", "Application-Error");
        }
    }
}
