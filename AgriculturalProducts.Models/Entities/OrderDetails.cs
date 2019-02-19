using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Models.Entities
{
    public class OrderDetails : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
