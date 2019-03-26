using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IUserInforRepository : IBaseRepository<UserInfor>
    {
        void CreatedUserInfor(UserInfor userInfor);
    }
}
