using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class Item
    {
        public ProductCart ProductCart { get; set; }

        public int Quantity { get; set; }
    }
}
