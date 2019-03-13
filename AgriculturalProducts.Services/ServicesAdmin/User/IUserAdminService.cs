﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AgriculturalProducts.Models;

namespace AgriculturalProducts.Services
{
    public interface IUserAdminService : IBlogsService<UserAdmin>
    {
        void CreatedUserAdmin(UserAdmin model);
        Task<UserAdmin> FindAdminUser(LoginDto login);
        Task<UserAdmin> CheckUserExists(string userName);
    }
}