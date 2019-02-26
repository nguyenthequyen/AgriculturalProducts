using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class Roles : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
