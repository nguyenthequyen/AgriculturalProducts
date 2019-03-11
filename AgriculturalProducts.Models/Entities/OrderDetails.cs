using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class OrderDetails : BaseEntity
    {
        public int Quantity { get; set; }
        public float TotalCost { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
