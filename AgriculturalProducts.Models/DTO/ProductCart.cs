using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class ProductCart : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public decimal Cost { get; set; }
    }
}
