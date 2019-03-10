using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public interface IUserClientRepository : IBaseRepository<User>
    {
        void CreatedUserCliet(User user);
        Task<User> FindClientUser(LoginDto login);
        Task<User> CheckUserExists(string userName);
        int UsersStatistics();
    }
}
