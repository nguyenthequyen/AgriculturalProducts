using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class ProductOrder
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
