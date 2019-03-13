using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class Order : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }
        public Guid StatusCartsId { get; set; }
        public StatusCart StatusCarts { get; set; }
        public User User { get; set; }
    }
}
