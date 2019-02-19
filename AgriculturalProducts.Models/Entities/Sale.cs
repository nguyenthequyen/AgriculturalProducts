using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class Sale : BaseEntity
    {
        public bool IsSale { get; set; }
        public int Percent { get; set; }
    }
}
