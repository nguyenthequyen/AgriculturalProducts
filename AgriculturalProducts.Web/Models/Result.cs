using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturalProducts.Web.Models
{
    public class Result
    {
        public int Code { get; set; }
        public string Error { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
