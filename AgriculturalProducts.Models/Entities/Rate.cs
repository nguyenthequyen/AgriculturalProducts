using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class Rate : BaseEntity
    {
        [Required]
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
