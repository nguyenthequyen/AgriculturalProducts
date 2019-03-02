using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    interface IUserClientService : IBaseService<User>
    {
        int UserStatisticsClient();
        Task<CreateUserResponse> Create(User user);
        void UpdateUserClient(List<User> user);
    }
}
