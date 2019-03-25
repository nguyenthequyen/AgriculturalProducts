using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IManagerUserRepository : IBaseRepository<User>
    {
        List<object> GetListUsers();
        List<object> GetListUsersSearchString(string name);
    }
}
