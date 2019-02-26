using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class OutPutModel<T>
    {
        public PageHeader Paging { get; set; }
        public List<T> Items { get; set; }
    }
}
