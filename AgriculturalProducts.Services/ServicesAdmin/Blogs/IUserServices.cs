using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services.ServicesAdmin.Blogs
{
    public interface IUserServices
    {
        bool ValidateUser(string username, string password);
    }
}
