using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class Comments : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
