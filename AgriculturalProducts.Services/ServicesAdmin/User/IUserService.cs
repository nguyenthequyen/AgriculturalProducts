using System;
using System.Collections.Generic;
using System.Text;
using AgriculturalProducts.Models;

namespace AgriculturalProducts.Services
{
    public interface IUserService : IBaseService<User>
    {
        void InsertUser(User user);
    }
}
