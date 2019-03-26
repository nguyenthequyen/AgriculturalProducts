using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface IUserClientService : IBaseService<User>
    {
        void CreatedUserCliet(UserModel user, Guid id);
        Task<User> FindClientUser(LoginDto login);
        Task<User> CheckUserExists(string userName);
        int UsersStatistics();
    }
}
