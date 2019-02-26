using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class PagingParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SearchString { get; set; }
    }
}
