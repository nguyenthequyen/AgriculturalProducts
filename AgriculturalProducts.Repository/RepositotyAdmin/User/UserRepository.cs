using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _applicationContext;
        public UserRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void CreatedUserAdmin(User user)
        {
            throw new NotImplementedException();
        }

        public void CreatedUserClient(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserAdmin(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserAdmin(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserClient(User user)
        {
            throw new NotImplementedException();
        }
    }
}
