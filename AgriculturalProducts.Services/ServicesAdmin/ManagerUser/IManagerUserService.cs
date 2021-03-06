﻿using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IManagerUserService : IBaseService<User>
    {
        PageList<object> GetListUsers(PagingParams pagingParams);
    }
}
