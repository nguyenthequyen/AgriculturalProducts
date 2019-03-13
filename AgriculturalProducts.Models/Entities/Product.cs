using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class Product : BaseEntity
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public int View { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public decimal Cost { get; set; }
        public decimal CostOld { get; set; }
        [Required]
        public decimal Mass { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string FullDescription { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int Sale { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public Guid ProviderId { get; set; }
        public Provider Provider { get; set; }
        [Required]
        public Guid ProductTypeId { get; set; }
        public ProductType Type { get; set; }
        [Required]
        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }
        [Required]
        public Guid StatusProductId { get; set; }
        public StatusProduct StatusProduct { get; set; }
    }
}
