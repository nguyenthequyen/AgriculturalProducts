using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturalProducts.Web.Models
{
    public class OrderDTo
    {
        public int Quantity { get; set; }
        public float TotalCost { get; set; }
        public Guid ProductId { get; set; }
    }
}
