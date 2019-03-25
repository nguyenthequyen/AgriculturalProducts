using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public class UserAdminService : BaseService<UserAdmin>, IUserAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IUserAdminRepository _userRepository;
        public UserAdminService(IUnitOfWork unitOfWork, IUserAdminRepository userRepository) : base(unitOfWork, userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public void CreatedUserAdmin(UserAdmin model)
        {
            var user = new UserAdmin
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                RolesId = model.RolesId,
                Password = model.Password,
                UserName = model.UserName
            };
            Add(user);
            _unitOfWork.Commit();
        }
        public async Task<UserAdmin> FindAdminUser(LoginDto login)
        {
            return await _userRepository.FindAdminUser(login);
        }

        public async Task<UserAdmin> CheckUserExists(string userName)
        {
            return await _userRepository.CheckUserExists(userName);
        }

        public async Task<Roles> GetRoles(Guid id)
        {
            return await _userRepository.GetRoles(id);
        }
    }
}
