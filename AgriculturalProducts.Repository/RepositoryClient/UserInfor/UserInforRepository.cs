using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class UserInforRepository : BaseRepository<UserInfor>, IUserInforRepository
    {
        private readonly ApplicationContext _applicationContext;
        public UserInforRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void CreatedUserInfor(UserInfor userInfor)
        {
            Add(userInfor);
        }
    }
}
