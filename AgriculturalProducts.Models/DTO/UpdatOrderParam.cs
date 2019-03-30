using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class UpdatOrderParam
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public Guid OrderDetailsId { get; set; }
        public int Quantity { get; set; }
        public Guid StatusCartId { get; set; }
        public string StatusCart { get; set; }
    }
}
