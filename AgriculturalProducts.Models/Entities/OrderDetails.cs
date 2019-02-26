using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgriculturalProducts.Models.Entities
{
    public class OrderDetails : BaseEntity
    {
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
