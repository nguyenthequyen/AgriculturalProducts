using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AgriculturalProducts.Models;

namespace AgriculturalProducts.Repository
{
    public interface IUserAdminRepository : IBaseRepository<UserAdmin>
    {
        void CreatedUserAdmin(UserAdmin user);
        Task<UserAdmin> FindAdminUser(LoginDto login);
        Task<UserAdmin> CheckUserExists(string userName);
    }
}
