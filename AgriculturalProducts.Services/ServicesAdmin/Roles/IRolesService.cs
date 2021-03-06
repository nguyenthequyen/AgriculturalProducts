﻿using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface IRolesService : IBaseService<Roles>
    {
        void InsertRoles(Roles roles);
        void UpdateRoles(Roles roles);
        IEnumerable<Roles> GetAllRoles();
        void DeleteRoles(Roles roles);
        Task<Roles> FindRolesById(Guid id);
        Roles GetRolesClient();
    }
}
