using System;
using System.Collections.Generic;
using System.Text;
using AgriculturalProducts.Models;

namespace AgriculturalProducts.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        void CreatedUserClient(User user);
    }
}
