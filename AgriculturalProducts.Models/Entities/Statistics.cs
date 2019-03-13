using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class Statistics : BaseEntity
    {
        public int Action { get; set; }
        public string ActionName { get; set; }
    }
}
