using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace AgriculturalProducts.Models
{
    public class User : BaseEntity
    {
        private string id;

        public User(string firstName, string lastName, string id, string userName)
        {
            FirstName = firstName;
            LastName = lastName;
            this.id = id;
            UserName = userName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Guid RolesId { get; set; }
        public Roles Roles { get; set; }
        //public IdentityUser IdentityUser { get; set; }
    }
}
