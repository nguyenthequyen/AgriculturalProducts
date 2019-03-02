using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AgriculturalProducts.Models;

namespace AgriculturalProducts.Services
{
    public interface IUserService : IBaseService<User>
    {
        void CreatedUserAdmin(List<User> user);
        void UpdateUserAdmin(List<User> user);
        void DeleteUserAdmin(List<User> user);
        Task<User> FindUserById(Guid id);
    }
}
