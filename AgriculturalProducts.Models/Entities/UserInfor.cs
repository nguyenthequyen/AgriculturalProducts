using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class UserInfor:BaseEntity
    {
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
