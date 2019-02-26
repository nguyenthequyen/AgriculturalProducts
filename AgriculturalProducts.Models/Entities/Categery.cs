using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
