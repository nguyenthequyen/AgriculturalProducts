﻿using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public class UserClientService : BaseService<User>, IUserClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserClientRepository _reponsitory;
        public UserClientService(IUnitOfWork unitOfWork, IUserClientRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _reponsitory = reponsitory;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> CheckUserExists(string userName)
        {
            return await _reponsitory.CheckUserExists(userName);
        }

        public void CreatedUserCliet(UserModel model, Guid id)
        {
            var user = new User
            {
                Id = id,
                CreatedDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                RolesId = model.RolesId,
                Password = model.Password,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName
            };
            Add(user);
            _unitOfWork.Commit();
        }

        public async Task<User> FindClientUser(LoginDto login)
        {
            return await _reponsitory.FindClientUser(login);
        }

        public int UsersStatistics()
        {
            return _reponsitory.UsersStatistics();
        }
    }
}
