using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class Image : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
