using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public interface IUserClientRepository : IBaseRepository<User>
    {
        int UserStatisticsClient();
        void CreatedUserClient(List<User> user);
        Task<CreateUserResponse> Create(User user);
        void UpdateUserClient(List<User> user);
    }
}
