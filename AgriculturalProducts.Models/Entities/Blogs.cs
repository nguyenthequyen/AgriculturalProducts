using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class Blogs : BaseEntity
    {
        public string Title { get; set; }
        public string Tags { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
    }
}
