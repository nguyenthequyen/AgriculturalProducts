﻿using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public class RolesService : BaseService<Roles>, IRolesService
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RolesService(IUnitOfWork unitOfWork, IRolesRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _rolesRepository = reponsitory;
            _unitOfWork = unitOfWork;
        }

        public void DeleteRoles(Roles roles)
        {
            Delete(roles);
        }

        public async Task<Roles> FindRolesById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }

        public IEnumerable<Roles> GetAllRoles()
        {
            return GetAllRecords();
        }

        public void InsertRoles(Roles roles)
        {
            roles.Id = Guid.NewGuid();
            roles.ModifyDate = DateTime.Now;
            roles.CreatedDate = DateTime.Now;
            Add(roles);
        }

        public void UpdateRoles(Roles roles)
        {
            roles.ModifyDate = DateTime.Now;
            Update(roles);
        }
    }
}