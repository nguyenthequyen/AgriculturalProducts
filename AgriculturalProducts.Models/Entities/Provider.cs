using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class Provider : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public DateTime DateTimeRegister { get; set; }
        public DateTime DateTimeStop { get; set; }
        public string Status { get; set; }
    }
}
