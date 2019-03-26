using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IUserInforService : IBaseService<UserInfor>
    {
        void CreatedUserInfor(UserInfor userInfor);
    }
}
