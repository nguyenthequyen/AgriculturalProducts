using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class Order : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int TotalQuantity { get; set; }
        public float TotalCost { get; set; }
        public int Processed { get; set; }
    }
}
