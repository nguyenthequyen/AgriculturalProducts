using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public class UserAdminRepository : BaseRepository<UserAdmin>, IUserAdminRepository
    {
        private readonly ApplicationContext _applicationContext;
        public UserAdminRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<UserAdmin> CheckUserExists(string userName)
        {
            return _applicationContext.UserAdmin.FirstOrDefault(x => x.UserName == userName);
        }

        public void CreatedUserAdmin(UserAdmin user)
        {
            Add(user);
        }

        public async Task<UserAdmin> FindAdminUser(LoginDto login)
        {
            return _applicationContext.UserAdmin.FirstOrDefault(x => x.UserName == login.Username && x.Password == login.Password);
        }
    }
}
