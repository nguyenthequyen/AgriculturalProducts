using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class StatusCart : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
