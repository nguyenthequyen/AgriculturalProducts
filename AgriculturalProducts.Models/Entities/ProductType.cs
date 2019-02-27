using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class ProductType : BaseEntity
    {
        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống")]
        public string Code { get; set; }
    }
}
