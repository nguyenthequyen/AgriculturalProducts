using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Models
{
    public class UserAdmin : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid RolesId { get; set; }
        public Roles Roles { get; set; }
    }
}
